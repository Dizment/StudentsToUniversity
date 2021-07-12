using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to fpmi.
    /// </summary>
    [JsonObject("fpmi")]
    public class BSUFacultyFpmi
    {
        /// <summary>
        /// Gets or sets min value for fpmi.
        /// </summary>
        /// <value>
        /// Min value for fpmi.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for fpmi.
        /// </summary>
        /// <value>
        /// Max value for fpmi.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for fpmi.
        /// </summary>
        /// <value>
        /// place value for fpmi.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
