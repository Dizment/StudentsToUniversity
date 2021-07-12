using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers
{
    /// <summary>
    /// contains properties for the request.
    /// </summary>
    public class AppCommandRequest
    {
        /// <summary>
        /// Gets or sets Command.
        /// </summary>
        /// <value>
        /// сommand name.
        /// </value>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets Parameters.
        /// </summary>
        /// <value>query parameters.</value>
        public string Parameters { get; set; }
    }
}
