using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to informtech.
    /// </summary>
    [JsonObject("informtech")]
    public class BSUIRFacultyInformTech
    {
        /// <summary>
        /// Gets or sets min value for informtech.
        /// </summary>
        /// <value>
        /// Min value for informtech.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for informtech.
        /// </summary>
        /// <value>
        /// Max value for informtech.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for informtech.
        /// </summary>
        /// <value>
        /// place value for informtech.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
