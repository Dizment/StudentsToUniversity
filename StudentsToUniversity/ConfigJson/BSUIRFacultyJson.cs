using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.ConfigJson
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BSUIRFacultyJson
    {
        /// <summary>
        /// Gets or sets ksis.
        /// </summary>
        /// <value>
        /// Ksis.
        /// </value>
        [JsonConverter(typeof(BSUIRFacultyKsis))]
        public BSUIRFacultyKsis Ksis { get; set; }

        /// <summary>
        /// Gets or sets RadioTech.
        /// </summary>
        /// <value>
        /// RadioTech.
        /// </value>
        [JsonConverter(typeof(BSUIRRadioTech))]
        public BSUIRRadioTech RadioTech { get; set; }

        /// <summary>
        /// Gets or sets InformTech.
        /// </summary>
        /// <value>
        /// InformTech.
        /// </value>
        [JsonConverter(typeof(BSUIRFacultyInformTech))]
        public BSUIRRadioTech InformTech { get; set; }
    }
}
