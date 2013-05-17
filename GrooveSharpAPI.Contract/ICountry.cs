using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI.Contract
{


    /// <summary>
    /// Interface ICountry
    /// </summary>
    public interface ICountry
    {
        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        Int64 ID { get; }
        /// <summary>
        /// Gets the C c1.
        /// </summary>
        /// <value>The C c1.</value>
        Int64 CC1 { get; }
        /// <summary>
        /// Gets the C c2.
        /// </summary>
        /// <value>The C c2.</value>
        Int64 CC2 { get; }
        /// <summary>
        /// Gets the C c3.
        /// </summary>
        /// <value>The C c3.</value>
        Int64 CC3 { get; }
        /// <summary>
        /// Gets the C c4.
        /// </summary>
        /// <value>The C c4.</value>
        Int64 CC4 { get; }
        /// <summary>
        /// Gets the DMA.
        /// </summary>
        /// <value>The DMA.</value>
        Int64 DMA { get; }
        /// <summary>
        /// Gets the IPR.
        /// </summary>
        /// <value>The IPR.</value>
        Int64 IPR { get; }

        /// <summary>
        /// To the json string.
        /// </summary>
        /// <returns>System.String.</returns>
        string ToJsonString();
    }

}
