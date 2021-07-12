using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    public class ImportCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;
        private static CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Input service.</param>
        public ImportCommandHandler(IFileCabinetService service)
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

            if (string.Equals(request.Command, "import", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Import(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void Import(string parameters)
        {
            try
            {
                string[] arguments = parameters.Trim().ToLower(cultureInfo).Split(" ", 2);

                if (arguments.Length < 2)
                {
                    Console.WriteLine("Incorrect command. Use --> import [file type] [path]");
                    return;
                }

                string fileType = arguments[0];
                string filePath = arguments[1];

                if (Path.HasExtension(filePath))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"File {filePath} is not exitst.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect path format.");
                    return;
                }

                switch (fileType)
                {
                    case "csv":
                        using (StreamReader streamReader = new StreamReader(filePath))
                        {
                            FileCabinetSnapshot fileCabinetServiceSnapshot = this.service.MakeSnapshot("all");
                            fileCabinetServiceSnapshot.LoadFromCsv(streamReader);
                            this.service.Restore(fileCabinetServiceSnapshot);
                        }

                        Console.WriteLine($"Records were imported from.");
                        break;
                    case "xml":
                        using (StreamReader streamReader = new StreamReader(filePath))
                        {
                            FileCabinetSnapshot fileCabinetServiceSnapshot = this.service.MakeSnapshot("all");
                            fileCabinetServiceSnapshot.LoadFromXml(streamReader);
                            this.service.Restore(fileCabinetServiceSnapshot);
                        }

                        Console.WriteLine($"Records were imported from.");
                        break;
                    default:
                        Console.WriteLine("Incorrect file type.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Students are not import. {ex.Message}");
            }
        }
    }
}
