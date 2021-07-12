using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to mechmat.
    /// </summary>
    [JsonObject("mechmat")]
    public class BSUFacultyMechMat
    {
        /// <summary>
        /// Gets or sets min value for mechmat.
        /// </summary>
        /// <value>
        /// Min value for mechmat.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for mechmat.
        /// </summary>
        /// <value>
        /// Max value for mechmat.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for mechmat.
        /// </summary>
        /// <value>
        /// place value for mechmat.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
