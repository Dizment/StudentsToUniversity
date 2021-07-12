using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    public class ListCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;
        private readonly Action<IEnumerable<FileCabinetStudent>> printer = StudentPrint;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Input service.</param>
        /// <param name="printer">Input printer.</param>
        public ListCommandHandler(IFileCabinetService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Special handles.
        /// </summary>
        /// <param name="request">Input record.</param>
        /// <returns>AppCommandRequest instance.</returns>
        public override AppCommandRequest Handle(AppCommandRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException($"The {nameof(request)} is null");
            }

            if (string.Equals(request.Command, "list", StringComparison.CurrentCultureIgnoreCase))
            {
                this.List(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void List(string parameters)
        {
            this.printer(this.service.GetRecords());
        }

        private static void StudentPrint(IEnumerable<FileCabinetStudent> records)
        {
            if (records is null)
            {
                Console.WriteLine($"The {nameof(records)} is null");
                return;
            }

            foreach (var record in records)
            {
                Console.Write("#" + record.Id + ", ");
                Console.Write(record.Gender == 'm' ? "male, " : "female, ");
                Console.Write(record.FirstName + ", ");
                Console.Write(record.LastName + ", ");
                Console.Write(record.DateOfBirth.ToString("yyyy-MMM-dd", CultureInfo.CurrentCulture) + ", ");
                Console.Write(record.totalRating + ", ");
                Console.Write(record.University + ", ");
                Console.Write(record.Faculty + ".");
                Console.WriteLine();
            }
        }
    }
}
