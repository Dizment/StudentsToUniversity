using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to energy.
    /// </summary>
    [JsonObject("energy")]
    public class BNTUFacultyEnergy
    {
        /// <summary>
        /// Gets or sets min value for energy.
        /// </summary>
        /// <value>
        /// Min value for energy.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for energy.
        /// </summary>
        /// <value>
        /// Max value for energy.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for energy.
        /// </summary>
        /// <value>
        /// place value for energy.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
