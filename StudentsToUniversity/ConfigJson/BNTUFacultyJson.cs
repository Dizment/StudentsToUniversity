using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BNTUFacultyJson
    {
        /// <summary>
        /// Gets or sets robots.
        /// </summary>
        /// <value>
        /// Robots.
        /// </value>
        [JsonConverter(typeof(BNTUFacultyRobots))]
        public BNTUFacultyRobots Robots { get; set; }

        /// <summary>
        /// Gets or sets energy.
        /// </summary>
        /// <value>
        /// Energy.
        /// </value>
        [JsonConverter(typeof(BNTUFacultyEnergy))]
        public BNTUFacultyEnergy Energy { get; set; }
    }
}
