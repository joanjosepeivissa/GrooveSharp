using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface IGrooveSharp
    /// </summary>
    public interface IGrooveSharp
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>The user.</value>
        IUser User { get; }
        /// <summary>
        /// Gets the groove country.
        /// </summary>
        /// <value>The groove country.</value>
        ICountry GrooveCountry { get; }
        /// <summary>
        /// Gets the session key.
        /// </summary>
        /// <value>The session key.</value>
        string SessionKey { get; }

        /// <summary>
        /// Initializes the session.
        /// </summary>
        /// <returns>System.String.</returns>
        string InitializeSession();

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        bool Login(string username, string token);

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        void Logout();

        /// <summary>
        /// Pings the server.
        /// </summary>
        /// <returns>System.String.</returns>
        string PingServer();
        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <returns>ICountry.</returns>
        ICountry GetCountry();
        /// <summary>
        /// Gets the popular songs today.
        /// </summary>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> GetPopularSongsToday();
        /// <summary>
        /// Gets the popular songs month.
        /// </summary>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> GetPopularSongsMonth();
        /// <summary>
        /// Searches the album.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable{IAlbum}.</returns>
        IEnumerable<IAlbum> SearchAlbum(string query);
        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable{IArtist}.</returns>
        IEnumerable<IArtist> SearchArtist(string query);
        /// <summary>
        /// Searches the playlist.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable{IPlaylist}.</returns>
        IEnumerable<IPlaylist> SearchPlaylist(string query);
        /// <summary>
        /// Searches the song.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> SearchSong(string query);
        /// <summary>
        /// Gets the song URL from song ID.
        /// </summary>
        /// <param name="songID">The song ID.</param>
        /// <returns>System.String.</returns>
        Uri GetSongURLFromSongID(int songID);
        /// <summary>
        /// Gets the songs info.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> GetSongsInfo(int[] ids);

        ISong GetSongInfo(int id);

        /// <summary>
        /// Occurs when [on request responded event].
        /// </summary>
        event OnRequestRespondedEventHandler OnRequestRespondedEvent;

    }
}
