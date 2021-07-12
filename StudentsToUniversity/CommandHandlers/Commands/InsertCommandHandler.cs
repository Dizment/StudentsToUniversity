using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    public class InsertCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;
        private const string RegexConstruction = @"^[\s]*[(][\s]*(?<temp1>[a-zA-Z\W]*[$a-zA-Z])[\s]*,[\s]*(?<temp2>[a-zA-Z\W]*[$a-zA-Z])[\s]*,[\s]*(?<temp3>[a-zA-Z\W]*[$a-zA-Z])[\s]*,[\s]*(?<temp4>[a-zA-Z\W]*[$a-zA-Z])[\s]*,[\s]*(?<temp5>[a-zA-Z\W]*[$a-zA-Z])[\s]*[)][\s]*values[\s]*[(][\s]*(?<value1>['][a-zA-Z0-9\W]+[$'])[\s]*, [\s]*(?<value2>['][a-zA-Z0-9\W]+[$'])[\s]*,[\s]*(?<value3>['][a-zA-Z0-9\W]+[$'])[\s]*,[\s]*(?<value4>['][a-zA-Z0-9\W]+[$'])[\s]*,[\s]*(?<value5>['][a-zA-Z0-9\W]+[$'])[\s]*[)]";

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Input service.</param>
        public InsertCommandHandler(IFileCabinetService service)
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

            if (string.Equals(request.Command, "insert", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Insert(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void Insert(string parameters)
        {
            try
            {
                Match match = Regex.Match(parameters, RegexConstruction);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                dictionary.Add(match.Groups["temp1"].Value.Trim('\''), match.Groups["value1"].Value.Trim('\''));
                dictionary.Add(match.Groups["temp2"].Value.Trim('\''), match.Groups["value2"].Value.Trim('\''));
                dictionary.Add(match.Groups["temp3"].Value.Trim('\''), match.Groups["value3"].Value.Trim('\''));
                dictionary.Add(match.Groups["temp4"].Value.Trim('\''), match.Groups["value4"].Value.Trim('\''));
                dictionary.Add(match.Groups["temp5"].Value.Trim('\''), match.Groups["value5"].Value.Trim('\''));

                bool correctStudent = true;
                string firstName = string.Empty;
                this.ReadInput<string>(dictionary, ref correctStudent, ref firstName, StringConverter, "firstname");
                string lastName = string.Empty;
                this.ReadInput<string>(dictionary, ref correctStudent, ref lastName, StringConverter, "lastname");
                DateTime dateofbirth = default;
                this.ReadInput<DateTime>(dictionary, ref correctStudent, ref dateofbirth, DateTimeConverter, "dateofbirth");
                char gender = default;
                this.ReadInput<char>(dictionary, ref correctStudent, ref gender, CharConverter, "gender");
                short totalrating = default;
                this.ReadInput<short>(dictionary, ref correctStudent, ref totalrating, ShortConverter, "totalrating");

                if (correctStudent)
                {
                    FileCabinetStudent student = new FileCabinetStudent()
                    {
                        Id = default,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Gender = gender,
                        totalRating = totalrating,
                        University = "-",
                        Faculty = "-",
                    };

                    this.service.Insert(student);
                    Console.WriteLine($"Student #{student.Id} is created.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Student is not created. {ex.Message}");
            }
        }

        private void ReadInput<T>(Dictionary<string, string> dictionary, ref bool dataCorrect, ref T field, Func<string, Tuple<bool, string, T>> converter, string fieldName)
        {
            if (!dictionary.ContainsKey(fieldName))
            {
                Console.WriteLine($"Field '{fieldName}' do not found.");
                dataCorrect = false;
            }
            else
            {
                var converted = converter.Invoke(dictionary[fieldName]);
                if (!converted.Item1)
                {
                    Console.WriteLine($"Conversion of '{fieldName}' failed: {converted.Item2}.");
                    dataCorrect = false;
                }
                else
                {
                    field = converted.Item3;
                }
            }
        }

        private static Tuple<bool, string, string> StringConverter(string data)
        {
            string result;

            try
            {
                result = data;
                return new Tuple<bool, string, string>(true, string.Empty, result);
            }
            catch (DirectoryNotFoundException ex)
            {
                return new Tuple<bool, string, string>(false, ex.Message, default);
            }
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

        private static Tuple<bool, string, short> ShortConverter(string data)
        {
            short result;

            if (short.TryParse(data, out result))
            {
                return new Tuple<bool, string, short>(true, string.Empty, result);
            }

            return new Tuple<bool, string, short>(false, string.Empty, default);
        }
        private static Tuple<bool, string, DateTime> DateTimeConverter(string data)
        {
            DateTime result;

            if (DateTime.TryParse(data, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                return new Tuple<bool, string, DateTime>(true, string.Empty, result);
            }

            return new Tuple<bool, string, DateTime>(false, string.Empty, default);
        }
    }
}
