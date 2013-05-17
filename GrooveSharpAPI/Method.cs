using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    internal enum Method
    {
        pingService,
        startSession,
        getUserInfo,
        getCountry,
        authenticate,
        getSongSearchResults,
        getStreamKeyStreamServer,
        getSubscriberStreamKey,
        getArtistSearchResults,
        getAlbumSearchResults,
        getPlaylistSearchResults,
        getUserPlaylists,
        getUserPlaylistsSubscribed,
        getUserFavoriteSongs,
        getUserSubscriptionDetails,
        getPopularSongsToday,
        getPopularSongsMonth,
        getServiceDescription,
        getPlaylistInfo,
        getPlaylist,
        getPlaylistSongs,
        addUserLibrarySongs,
        getAlbumSongs,
        markStreamKeyOver30Secs,
        getSongsInfo,
        getSongURLFromSongID
    }
}
