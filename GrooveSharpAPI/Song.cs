using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class Song : ISong
    {
        public int ID { get; internal set; }
        public string Title { get; internal set; }
        public IArtist Artist { get; internal set; }
        public IAlbum Album { get; internal set; }
        public long Popularity { get; internal set; }
        public bool IsLowBitrateAvailable { get; internal set; }
        public bool IsVerified { get; internal set; }
        public int Flags { get; internal set; }

        private GrooveSharp grooveSharp = null;

        internal Song() { }

        internal static IEnumerable<Song> parseToList(GrooveSharp grooveSharp, string json)
        {
            List<Song> _retVal = new List<Song>();
            var _el = Snippet.ToXElementCollection(json);

            _el.Where(e => e.Name == "songs").ToList().ForEach(e =>
            {
                var _inner = e.Elements();
                Artist _artist = new Artist()
                {
                    ID = Convert.ToInt32(_inner.Where(i => i.Name == "ArtistID").First().Value),
                    Name = _inner.Where(i => i.Name == "ArtistName").First().Value
                };

                Album _album = new Album()
                {
                    ID = Convert.ToInt32(_inner.Where(i => i.Name == "AlbumID").First().Value),
                    Name = _inner.Where(i => i.Name == "AlbumName").First().Value,
                    CoverArtFileName = _inner.Where(i => i.Name == "CoverArtFilename").First().Value,
                    Artist = _artist
                };

                var _ver = _inner.Where(i => i.Name == "IsVerified").First().Value;
                var _lowB = _inner.Where(i => i.Name == "IsLowBitrateAvailable").First().Value;

                if (_ver == "1")
                    _ver = "True";
                else if (_ver == "0")
                    _ver = "False";

                if (_lowB == "1")
                    _lowB = "True";
                else if (_lowB == "0")
                    _lowB = "False";

                bool _isVerified = Convert.ToBoolean(_ver);
                bool _isLowBitRate = Convert.ToBoolean(_lowB);

                Song _song = new Song()
                {
                    Album = _album,
                    ID = Convert.ToInt32(_inner.Where(i => i.Name == "SongID").First().Value),
                    Title = _inner.Where(i => i.Name == "SongName").First().Value,
                    Artist = _artist,
                    Popularity = Convert.ToInt64(_inner.Where(i => i.Name == "Popularity").First().Value),
                    IsLowBitrateAvailable = _isLowBitRate,
                    IsVerified = _isVerified,
                    Flags = Convert.ToInt32(_inner.Where(i => i.Name == "Flags").First().Value)
                };

                _song.grooveSharp = grooveSharp;

                _retVal.Add(_song);
            });

            return _retVal.AsEnumerable();
        }

        public static Song ConvertToSong(
            int id,
            string title,
            string artist,
            string album
            )
        {
            Song _song = new Song()
            {
                Title = title,
                Artist = new Artist()
                {
                    Name = artist
                },
                Album = new Album()
                {
                    Name = album
                }
            };

            return _song;
        }

        public ISubStream GetSubscriberStream()
        {
            RequestData _requestData = new RequestData(Method.getSubscriberStreamKey,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            _requestData.AddParameter("songID", ID);
            _requestData.AddParameter("country", grooveSharp.GrooveCountry);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return SubStream.parse(_response, grooveSharp);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
