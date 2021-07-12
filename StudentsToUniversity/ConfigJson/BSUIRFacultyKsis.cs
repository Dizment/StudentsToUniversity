using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to robots.
    /// </summary>
    [JsonObject("ksis")]
    public class BSUIRFacultyKsis
    {
        /// <summary>
        /// Gets or sets min value for robots.
        /// </summary>
        /// <value>
        /// Min value for robots.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for robots.
        /// </summary>
        /// <value>
        /// Max value for robots.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for robots.
        /// </summary>
        /// <value>
        /// place value for robots.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
