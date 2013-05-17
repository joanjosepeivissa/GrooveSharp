using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    internal static class Core
    {
        public static string pingServer(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.pingService, grooveSharp.APIKey);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Snippet.ToXElementCollection(_response).First().Value;
        }

        public static string getAlbumSongs(this GrooveSharp grooveSharp, int albumID)
        {
            RequestData _requestData = new RequestData(Method.getAlbumSongs, grooveSharp.APIKey);

            _requestData.AddParameter("albumID", albumID);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return _response;
        }

        public static string startSession(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.startSession, grooveSharp.APIKey);

            return grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);
        }

        public static Country getCountry(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.getCountry,
                grooveSharp.APIKey, IPAddress.Parse(grooveSharp.getWANAddress()));

            string _url = grooveSharp.getUrl(_requestData);
            string _response = grooveSharp.getResponse(_url, _requestData);

            return Country.parse(_response);
        }

        public static User getUserInfo(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.getUserInfo,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            User _user = User.Parse(grooveSharp, _response);

            return _user;
        }

        public static User login(this GrooveSharp grooveSharp, string username, string md5Password)
        {
            try
            {
                RequestData _requestData = new RequestData(Method.authenticate,
                    grooveSharp.APIKey, grooveSharp.SessionKey);

                _requestData.AddParameter("login", username);
                _requestData.AddParameter("password", md5Password);

                string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

                if (_response.Contains("\"UserID\":0"))
                    throw new GrooveException("User not found!");

                User _user = User.Parse(grooveSharp, _response);

                return _user;
            }
            catch (GrooveException)
            {
                throw;
            }
        }

        public static IEnumerable<ISong> getSongsInfo(this GrooveSharp grooveSharp, IEnumerable<int> songID)
        {
            RequestData _requestData = new RequestData(Method.getSongsInfo,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            _requestData.AddParameter("songIDs", songID.ToArray());

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);


            return Song.parseToList(grooveSharp, _response);
        }

        public static string getSongURLFromSongID(this GrooveSharp grooveSharp, int songID)
        {
            RequestData _requestData = new RequestData(Method.getSongURLFromSongID,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            _requestData.AddParameter("songID", songID);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return _response;
        }

        public static IEnumerable<Song> getPopularSongsToday(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.getPopularSongsToday,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            string _respond = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Song.parseToList(grooveSharp, _respond);
        }

        public static IEnumerable<Song> getPopularSongsMonth(this GrooveSharp grooveSharp)
        {
            RequestData _requestData = new RequestData(Method.getPopularSongsMonth,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            string _respond = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Song.parseToList(grooveSharp, _respond);
        }
    }
}
