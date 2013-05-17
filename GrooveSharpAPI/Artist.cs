using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    public class Artist : IArtist
    {
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public bool IsVerified { get; internal set; }

        internal Artist() { }

        internal static List<Artist> parseToList(GrooveSharp grooveSharp, string jsonData)
        {
            List<Artist> _artists = new List<Artist>();
            var _data = Snippet.ToXElementCollection(jsonData);

            _data.Where(e => e.Name == "artists").Select(e => e).ToList().ForEach(e =>
            {
                Artist _artist = new Artist()
                {
                    ID = Convert.ToInt32(e.Elements().Where(i => i.Name == "ArtistID").First().Value),
                    Name = e.Elements().Where(i => i.Name == "ArtistName").First().Value,
                    IsVerified = Convert.ToBoolean(e.Elements().Where(i => i.Name == "IsVerified").First().Value)
                };

                _artists.Add(_artist);
            });


            return _artists;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
