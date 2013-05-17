using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface IPlaylist
    /// </summary>
    public interface IPlaylist
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
        /// Gets the added.
        /// </summary>
        /// <value>The added.</value>
        DateTime Added { get; }
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>The user.</value>
        IUser User { get; }

        /// <summary>
        /// Gets the songs.
        /// </summary>
        /// <returns>IEnumerable{ISong}.</returns>
        IEnumerable<ISong> GetSongs();
    }
}
