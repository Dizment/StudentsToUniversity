using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to radiotech.
    /// </summary>
    [JsonObject("radiotech")]
    public class BSUIRRadioTech
    {
        /// <summary>
        /// Gets or sets min value for radiotech.
        /// </summary>
        /// <value>
        /// Min value for radiotech.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for radiotech.
        /// </summary>
        /// <value>
        /// Max value for radiotech.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for radiotech.
        /// </summary>
        /// <value>
        /// place value for radiotech.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
