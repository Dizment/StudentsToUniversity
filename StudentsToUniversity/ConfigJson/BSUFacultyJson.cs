using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BSUFacultyJson
    {
        /// <summary>
        /// Gets or sets RadioPhys.
        /// </summary>
        /// <value>
        /// RadioPhys.
        /// </value>
        [JsonConverter(typeof(BSUFacultyRadioPhys))]
        public BSUFacultyRadioPhys RadioPhys { get; set; }

        /// <summary>
        /// Gets or sets fpmi.
        /// </summary>
        /// <value>
        /// fpmi.
        /// </value>
        [JsonConverter(typeof(BSUFacultyFpmi))]
        public BSUFacultyFpmi Fpmi { get; set; }

        /// <summary>
        /// Gets or sets mechmat.
        /// </summary>
        /// <value>
        /// mechmat.
        /// </value>
        [JsonConverter(typeof(BSUFacultyMechMat))]
        public BSUFacultyMechMat MechMat { get; set; }
    }
}
