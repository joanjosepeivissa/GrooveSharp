using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GrooveSharpAPI
{
    public class Album : IAlbum
    {
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public IArtist Artist { get; internal set; }
        public string CoverArtFileName { get; internal set; }
        public bool IsVerified { get; internal set; }

        private GrooveSharp grooveSharp = null;

        internal Album() { }

        internal static IEnumerable<Album> getListOfAlbums(GrooveSharp grooveSharp, string json)
        {
            List<Album> _retVal = new List<Album>();
            var _data = Snippet.ToXElementCollection(json);

            _data.Where(e => e.Name == "albums").Select(e => e).ToList().ForEach(e =>
                {
                    Artist _artist = new Artist()
                    {
                        ID = Convert.ToInt32(e.Elements().Where(i => i.Name == "ArtistID").First().Value),
                        Name = e.Elements().Where(i => i.Name == "ArtistName").First().Value                        
                    };

                    Album _album = new Album()
                    {
                        ID = Convert.ToInt32(e.Elements().Where(i => i.Name == "AlbumID").First().Value),
                        Name = e.Elements().Where(i => i.Name == "AlbumName").First().Value,
                        CoverArtFileName = e.Elements().Where(i => i.Name == "CoverArtFilename").First().Value,
                        IsVerified = Convert.ToBoolean(e.Elements().Where(i => i.Name == "IsVerified").First().Value),
                        Artist = _artist,
                        grooveSharp = grooveSharp
                    };

                    _retVal.Add(_album);
                });

            return _retVal;
        }

        public IEnumerable<ISong> GetSongs()
        {
            string _response = grooveSharp.getAlbumSongs(ID);

            return Song.parseToList(grooveSharp, _response);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
