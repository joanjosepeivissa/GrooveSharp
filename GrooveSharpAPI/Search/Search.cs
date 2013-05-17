using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    internal static class Search
    {
        public static IEnumerable<Album> searchAlbum(this GrooveSharp grooveSharp, string query)
        {
            try
            {
                RequestData _requestData = new RequestData(Method.getAlbumSearchResults, grooveSharp.APIKey);

                _requestData.AddParameter("query", query);

                string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

                return Album.getListOfAlbums(grooveSharp, _response);
            }
            catch (GrooveException)
            {
                throw;
            }
        }

        public static IEnumerable<Artist> searchArtist(this GrooveSharp grooveSharp, string query)
        {
            RequestData _requestData = new RequestData(Method.getArtistSearchResults, grooveSharp.APIKey);

            _requestData.AddParameter("query", query);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Artist.parseToList(grooveSharp, _response);
        }

        public static IEnumerable<Playlist> searchPlaylist(this GrooveSharp grooveSharp, string query)
        {
            RequestData _requestData = new RequestData(Method.getPlaylistSearchResults, grooveSharp.APIKey);
            _requestData.AddParameter("query", query);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

            return Playlist.parseToList(grooveSharp, _response);
        }

        public static IEnumerable<Song> searchSong(this GrooveSharp grooveSharp, string query)
        {
            try
            {
                RequestData _requestData = new RequestData(Method.getSongSearchResults, grooveSharp.APIKey);
                _requestData.AddParameter("query", query);
                _requestData.AddParameter("country", grooveSharp.GrooveCountry.ToJsonString());

                string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);

                return Song.parseToList(grooveSharp, _response);
            }
            catch (GrooveException)
            {
                throw;
            }
        }
    }
}
