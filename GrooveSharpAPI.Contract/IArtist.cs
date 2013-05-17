using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{

    /// <summary>
    /// Interface IArtist
    /// </summary>
    public interface IArtist
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
        /// Gets a value indicating whether this instance is verified.
        /// </summary>
        /// <value><c>true</c> if this instance is verified; otherwise, <c>false</c>.</value>
        bool IsVerified { get; }
    }
}
