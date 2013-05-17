using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class User : IUser
    {
        private string password = string.Empty;
        private string token = string.Empty;
        private GrooveSharp grooveSharp = null;

        public int ID { get; internal set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        public bool IsPremium { get; internal set; }
        public bool IsPlus { get; internal set; }
        public bool IsAnywhere { get; internal set; }

        public string Token
        {
            get
            {
                if (!string.IsNullOrEmpty(token))
                    return token;

                if (!string.IsNullOrEmpty(password))
                    return CalculateMD5Hash(password);

                return string.Empty;
            }
            private set
            {
                token = value;
            }
        }

        public string Username { get; set; }

        public string Password
        {
            set
            {
                password = value;
            }
        }
        public string Email { get; set; }

        internal User() { }

        internal static User Parse(GrooveSharp grooveSharp, string jsonData)
        {
            var _el = Snippet.ToXElementCollection(jsonData);

            string _email = (_el.Where(e => e.Name == "Email").FirstOrDefault() == null) ?
                "" : _el.Where(e => e.Name == "Email").FirstOrDefault().Value;

            User _user = new User()
            {
                ID = Convert.ToInt32(_el.Where(e => e.Name == "UserID").First().Value),
                LastName = _el.Where(e => e.Name == "LName").First().Value,
                FirstName = _el.Where(e => e.Name == "FName").First().Value,
                IsPlus = Convert.ToBoolean(_el.Where(e => e.Name == "IsPlus").First().Value),
                IsPremium = Convert.ToBoolean(_el.Where(e => e.Name == "IsPremium").First().Value),
                IsAnywhere = Convert.ToBoolean(_el.Where(e => e.Name == "IsAnywhere").First().Value),
                Email = _email
            };

            _user.grooveSharp = grooveSharp;

            return _user;
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 _md5 = System.Security.Cryptography.MD5.Create();
            byte[] _inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] _hash = _md5.ComputeHash(_inputBytes);

            StringBuilder _sb = new StringBuilder();
            for (int i = 0; i < _hash.Length; i++)
            {
                _sb.Append(_hash[i].ToString("X2"));
            }

            return _sb.ToString();
        }

        public IEnumerable<IPlaylist> GetPlaylists()
        {
            RequestData _requestData = new RequestData(Method.getUserPlaylists,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            List<Playlist> _playList = Playlist.parseToList(grooveSharp, _response);

            return _playList;
        }        

        public override string ToString()
        {
            return FullName;
        }
    }
}
