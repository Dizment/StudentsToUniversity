using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    /// <summary>
    /// Class for configurating universitys.
    /// </summary>
    public class UniversityJson
    {
        /// <summary>
        /// Gets or sets universitys.
        /// </summary>
        /// <value>
        /// BSUIR.
        /// </value>
        [JsonConverter(typeof(BSUFacultyJson))]
        public BSUIRFacultyJson BSUIR { get; set; }

        /// <summary>
        /// Gets or sets universitys.
        /// </summary>
        /// <value>
        /// BSU.
        /// </value>
        [JsonConverter(typeof(BSUFacultyJson))]
        public BSUFacultyJson BSU { get; set; }

        /// <summary>
        /// Gets or sets universitys.
        /// </summary>
        /// <value>
        /// BNTU.
        /// </value>
        [JsonConverter(typeof(BSUFacultyJson))]
        public BNTUFacultyJson BNTU { get; set; }
    }
}
