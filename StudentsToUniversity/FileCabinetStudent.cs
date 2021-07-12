using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity
{
    /// <summary>
    /// This class include propertys of record.
    /// </summary>
    public class FileCabinetStudent
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Number of record.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose gender.</value>
        public char Gender { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose second name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose date of birth.</value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose totalRating.</value>
        public short totalRating { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose University.</value>
        public string University { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>Choose Faculty.</value>
        public string Faculty { get; set; }
    }
}

