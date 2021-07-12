using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for add configuration to radiophys.
    /// </summary>
    [JsonObject("radiophys")]
    public class BSUFacultyRadioPhys
    {
        /// <summary>
        /// Gets or sets min value for radiophys.
        /// </summary>
        /// <value>
        /// Min value for radiophys.
        /// </value>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets max value for radiophys.
        /// </summary>
        /// <value>
        /// Max value for radiophys.
        /// </value>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets place value for radiophys.
        /// </summary>
        /// <value>
        /// place value for radiophys.
        /// </value>
        [JsonProperty("place")]
        public int Place { get; set; }
    }
}
