using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface ISong
    /// </summary>
    public interface ISong
    {
        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        int ID { get; }
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; }
        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <value>The artist.</value>
        IArtist Artist { get; }
        /// <summary>
        /// Gets the album.
        /// </summary>
        /// <value>The album.</value>
        IAlbum Album { get; }
        /// <summary>
        /// Gets the popularity.
        /// </summary>
        /// <value>The popularity.</value>
        long Popularity { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is low bitrate available.
        /// </summary>
        /// <value><c>true</c> if this instance is low bitrate available; otherwise, <c>false</c>.</value>
        bool IsLowBitrateAvailable { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is verified.
        /// </summary>
        /// <value><c>true</c> if this instance is verified; otherwise, <c>false</c>.</value>
        bool IsVerified { get; }
        /// <summary>
        /// Gets the flags.
        /// </summary>
        /// <value>The flags.</value>
        int Flags { get; }

        /// <summary>
        /// Gets the subscriber stream.
        /// </summary>
        /// <returns>ISubStream.</returns>
        ISubStream GetSubscriberStream();
    }
}
