using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{
    /// <summary>
    /// Interface ISubStream
    /// </summary>
    public interface ISubStream
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        string Key { get; }
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>The URL.</value>
        Uri Url { get; }
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>The time.</value>
        TimeSpan Time { get; }
        /// <summary>
        /// Gets the server ID.
        /// </summary>
        /// <value>The server ID.</value>
        int ServerID { get; }

        /// <summary>
        /// Marks as over30 seconds.
        /// </summary>
        void MarkAsOver30Seconds();
    }
}
