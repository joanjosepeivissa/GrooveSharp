using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    public class Playlist : IPlaylist
    {
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public DateTime Added { get; internal set; }
        public IUser User { get; internal set; }

        private GrooveSharp grooveSharp = null;

        internal Playlist() { }

        internal static List<Playlist> parseToList(GrooveSharp grooveSharp, string jsonData)
        {
            List<Playlist> _playlist = new List<Playlist>();
            var _data = Snippet.ToXElementCollection(jsonData);

            _data.Where(e => e.Name == "playlists").Select(e => e).ToList().ForEach(e =>
                {
                    User _user = new User();

                    try
                    {
                        _user.ID = Convert.ToInt32(e.Elements().Where(i => i.Name == "UserID").First().Value);
                        _user.FirstName = e.Elements().Where(i => i.Name == "FName").First().Value;
                        _user.LastName = e.Elements().Where(i => i.Name == "LName").First().Value;
                    }
                    catch { }

                    DateTime _dateTime = DateTime.Now;

                    try
                    {
                        _dateTime = DateTime.Parse(e.Elements().Where(i => i.Name == "TSAdded").First().Value);
                    }
                    catch { }

                    Playlist _p = new Playlist()
                    {
                        ID = Convert.ToInt32(e.Elements().Where(i => i.Name == "PlaylistID").First().Value),
                        Name = e.Elements().Where(i => i.Name == "PlaylistName").First().Value,
                        Added = _dateTime,
                        User = _user,
                        grooveSharp = grooveSharp
                    };

                    _playlist.Add(_p);
                });


            return _playlist;
        }

        public IEnumerable<ISong> GetSongs()
        {
            List<Song> _songs = new List<Song>();

            RequestData _requestData = new RequestData(Method.getPlaylistSongs, grooveSharp.APIKey);
            _requestData.AddParameter("playlistID", ID);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Song.parseToList(grooveSharp, _response);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
