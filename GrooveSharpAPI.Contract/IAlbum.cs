using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface IAlbum
    /// </summary>
    public interface IAlbum
    {
        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        int ID { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <value>The artist.</value>
        IArtist Artist { get; }
        /// <summary>
        /// Gets the name of the cover art file.
        /// </summary>
        /// <value>The name of the cover art file.</value>
        string CoverArtFileName { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is verified.
        /// </summary>
        /// <value><c>true</c> if this instance is verified; otherwise, <c>false</c>.</value>
        bool IsVerified { get; }

        /// <summary>
        /// Gets the songs.
        /// </summary>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> GetSongs();
    }
}
