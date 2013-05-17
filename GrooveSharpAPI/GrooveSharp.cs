using GrooveSharpAPI.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class GrooveSharp : IGrooveSharp
    {
        private const string grooveSharkAPI = "api.grooveshark.com/ws3.php";

        private string apiKey = string.Empty;
        private string apiSecret = string.Empty;
        private string sessionKey = string.Empty;
        private ICountry grooveCountry;
        private User user = null;

        /// <summary>
        /// Gets the current logged in user.
        /// </summary>
        public IUser User 
        {
            get
            {
                return user;
            }
            private set
            {
                user = (User)value;
            }
        }

        /// <summary>
        /// Gets or sets your country.
        /// </summary>
        public ICountry GrooveCountry
        {
            get
            {
                if (grooveCountry == null)
                    throw new GrooveException("Country is null or empty. Initialize first.");

                return grooveCountry;
            }
            private set
            {
                grooveCountry = value;
            }
        }

        /// <summary>
        /// Gets the key value of the API to access the web service.
        /// </summary>
        internal string APIKey
        {
            get
            {
                if (string.IsNullOrEmpty(apiKey))                
                    throw new GrooveException("ApiKey is empty");                

                return apiKey;
            }
            set
            {
                apiKey = value;
            }
        }

        /// <summary>
        /// Gets the secret value of the API to access the web service.
        /// </summary>
        internal string APISecret
        {
            get
            {
                if (string.IsNullOrEmpty(apiSecret))
                    throw new GrooveException("ApiSecret is empty");

                return apiSecret;
            }
            set
            {
                apiSecret = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the request will be sent is secured using https.
        /// </summary>
        internal bool isHTTPS { get; set; }

        /// <summary>
        /// Sets the session key.
        /// </summary>
        public string SessionKey
        {
            get
            {
                if (string.IsNullOrEmpty(sessionKey))
                    throw new GrooveException("Session key not set.");

                return sessionKey;
            }
            private set
            {
                sessionKey = value;
            }
        }

        public event OnRequestRespondedEventHandler OnRequestRespondedEvent;

        public static IGrooveSharp Init(string key, string secret)
        {
            GrooveSharp _gSharp = new GrooveSharp(key, secret);
            _gSharp.isHTTPS = true;

            return _gSharp;
        }

        private GrooveSharp(string key, string secret)
        {
            APIKey = key;
            APISecret = secret;
        }        
        
        /// <summary>
        /// Initialize the session to access the web service.
        /// </summary>
        /// <returns>Returns the string representation of the session key.</returns>
        public string InitializeSession()
        {
            if (string.IsNullOrEmpty(APIData.SessionData))
            {
                string _response = this.startSession();
                APIData.SessionData = Snippet.ToXElementCollection(_response).Where(e => e.Name == "sessionID").First().Value;
            }

            SessionKey = APIData.SessionData;

            GrooveCountry = this.getCountry();
            User _currentUser = this.getUserInfo();

            if (_currentUser.ID == 0)
                user = null;
            else
                user = _currentUser;

            return APIData.SessionData;
        }

        public bool Login(string username, string token)
        {
            try
            {
                User _response = this.login(username, token);

                if (_response.Email != null)
                {
                    if (_response.ID == 0)
                        return false;
                }

                user = _response;

                return _response.Email != null;
            }
            catch(GrooveException)
            {
                throw;
            }            
        }

        public void Logout()
        {
            APIData.SessionData = string.Empty;
            SessionKey = string.Empty;
            User = null;
            GrooveCountry = null;
        }

        public string PingServer()
        {
            return this.pingServer();
        }

        internal string getUrl(RequestData requestData)
        {
            byte[] _key = Encoding.ASCII.GetBytes(APISecret);
            string _sig = encodeJsonToSig(requestData.GetJsonData(), _key);
            
            return string.Format("{0}://{1}?sig={2}", (isHTTPS)? "https" : "http", grooveSharkAPI, _sig);
        }

        internal string getResponse(string url, RequestData requestData)
        {
            string _retVal = string.Empty;
            WebRequest _request = WebRequest.Create(url);

            _request.Method = "POST";

            string _data = requestData.GetJsonData();

            using (Stream _stream = _request.GetRequestStream())
            {
                _stream.Write(requestData.GetByteArrayData(), 0, requestData.GetByteArrayData().Length);
            }

            WebResponse _response = _request.GetResponse();

            using (StreamReader _reader = new StreamReader(_response.GetResponseStream()))
            {
                _retVal = _reader.ReadToEnd();
            }

            if (OnRequestRespondedEvent != null)
                OnRequestRespondedEvent(_retVal);

            XDocument _doc = JsonConvert.DeserializeXNode(_retVal, "response");

            var _errorElem = _doc.Element("response").Element("errors");

            if (_errorElem != null)
                throw new GrooveException(_errorElem);

            return _retVal;
        }

        internal string encodeJsonToSig(string input, byte[] key)
        {
            HMACMD5 _hmacMd5 = new HMACMD5(key);
            byte[] _byteArr = Encoding.ASCII.GetBytes(input);
            string _retVal = string.Empty;

            using (MemoryStream _stream = new MemoryStream(_byteArr))
            {
                _retVal = _hmacMd5.ComputeHash(_stream).Aggregate("",
                (s, e) => s + String.Format("{0:x2}", e),
                s => s);
            }

            return _retVal;
        }       

        internal string getWANAddress()
        {
            using (WebClient _wc = new WebClient())
            {
                try
                {
                    string _ip = _wc.DownloadString("http://checkip.dyndns.org/");

                    Regex _regex = new Regex(@"\d{0,3}\.\d{0,3}\.\d{0,3}\.\d{0,3}");

                    string _value = _regex.Match(_ip).Value.Trim();

                    return _value;
                }
                catch
                {
                    return "0.0.0.0";
                }
            }            
        }

        public ICountry GetCountry()
        {
            return this.GrooveCountry;
        }

        public IEnumerable<ISong> GetPopularSongsToday()
        {
            return this.getPopularSongsToday();
        }

        public IEnumerable<ISong> GetPopularSongsMonth()
        {
            return this.getPopularSongsMonth();
        }

        public IEnumerable<ISong> GetSongsInfo(int[] ids)
        {
            return this.getSongsInfo(ids);
        }

        public ISong GetSongInfo(int id)
        {
            return this.getSongsInfo(new[] { id }).FirstOrDefault();
        }

        public IEnumerable<IAlbum> SearchAlbum(string query)
        {
            return this.searchAlbum(query);
        }

        public IEnumerable<IArtist> SearchArtist(string query)
        {
            return this.searchArtist(query);
        }

        public IEnumerable<IPlaylist> SearchPlaylist(string query)
        {
            return this.searchPlaylist(query);
        }

        public IEnumerable<ISong> SearchSong(string query)
        {
            return this.searchSong(query);
        }

        public Uri GetSongURLFromSongID(int songID)
        {
            return new Uri(this.getSongURLFromSongID(songID));
        }


        
    }
}
