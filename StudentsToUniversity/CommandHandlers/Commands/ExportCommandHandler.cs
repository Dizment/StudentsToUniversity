using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    public class ExportCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;
        private static CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Input service.</param>
        public ExportCommandHandler(IFileCabinetService service)
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

            if (string.Equals(request.Command, "export", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Export(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void Export(string parameters)
        {
            string[] arguments = parameters.Trim().ToLower(cultureInfo).Split(" ", 3);

            if (arguments.Length < 3)
            {
                Console.WriteLine("Incorrect comand format. Use --> export [file type] [path] [university/all]");
                return;
            }

            string path = arguments[1];

            if (Path.HasExtension(path) || File.Exists(path))
            {
                Console.Write($"File is exist - rewrite {path}? [Y/n]");
                char result = ReadInput(CharConverter, CancellingValidator);

                if (result == 'n')
                {
                    Console.WriteLine($"Export to file {path} was cancelled.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Incorrect path format.");
                return;
            }

            switch (arguments[0])
            {
                case "csv":
                    try
                    {
                        using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8))
                        {
                            FileCabinetSnapshot fileCabinetServiceSnapshot = this.service.MakeSnapshot(arguments[2]);
                            fileCabinetServiceSnapshot.SaveToCsv(streamWriter);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine($"Export failed: can't open file {path}.");
                        return;
                    }

                    Console.WriteLine($"All records are exported to file {path}.");
                    break;
                case "xml":
                    try
                    {
                        using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8))
                        {
                            FileCabinetSnapshot fileCabinetServiceSnapshot = this.service.MakeSnapshot(arguments[2]);
                            fileCabinetServiceSnapshot.SaveToXml(streamWriter);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine($"Export failed: can't open file {path}.");
                        return;
                    }

                    Console.WriteLine($"All records are exported to file {path}.");
                    break;
                default:
                    Console.WriteLine("Input name property not found.");
                    break;
            }
        }

        private static T ReadInput<T>(Func<string, Tuple<bool, string, T>> converter, Func<T, Tuple<bool, string>> validator)
        {
            do
            {
                T value;

                var input = Console.ReadLine();
                var conversionResult = converter(input);

                if (!conversionResult.Item1)
                {
                    Console.WriteLine($"Conversion failed: {conversionResult.Item2}. Please, correct your input.");
                    continue;
                }

                value = conversionResult.Item3;

                var validationResult = validator(value);
                if (!validationResult.Item1)
                {
                    Console.WriteLine($"Validation failed: {validationResult.Item2}. Please, correct your input.");
                    continue;
                }

                return value;
            }
            while (true);
        }

        private static Tuple<bool, string, char> CharConverter(string data)
        {
            char result;

            if (char.TryParse(data, out result))
            {
                return new Tuple<bool, string, char>(true, string.Empty, result);
            }

            return new Tuple<bool, string, char>(false, string.Empty, default);
        }

        private static Tuple<bool, string> CancellingValidator(char data)
        {
            if (!(data == 'y' || data == 'Y' || data == 'n' || data == 'N'))
            {
                return new Tuple<bool, string>(false, "Expected 'Y' or 'N'");
            }

            return new Tuple<bool, string>(true, "Success");
        }
    }
}
