using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface IUser
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        int ID { get; }
        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        string LastName { get; }
        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; }
        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        string FullName { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is premium.
        /// </summary>
        /// <value><c>true</c> if this instance is premium; otherwise, <c>false</c>.</value>
        bool IsPremium { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is plus.
        /// </summary>
        /// <value><c>true</c> if this instance is plus; otherwise, <c>false</c>.</value>
        bool IsPlus { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is anywhere.
        /// </summary>
        /// <value><c>true</c> if this instance is anywhere; otherwise, <c>false</c>.</value>
        bool IsAnywhere { get; }
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        string Email { get; }

        /// <summary>
        /// Gets the playlists.
        /// </summary>
        /// <returns>IEnumerable{IPlaylist}.</returns>
        IEnumerable<IPlaylist> GetPlaylists();
    }
}
