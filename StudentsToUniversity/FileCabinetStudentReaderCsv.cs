using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace StudentsToUniversity
{
    public class FileCabinetStudentReaderCsv
    {
        private readonly StreamReader streamReader;
        private readonly CultureInfo cultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetStudentReaderCsv"/> class.
        /// </summary>
        /// <param name="streamReader">StreamReader instance.</param>
        public FileCabinetStudentReaderCsv(StreamReader streamReader)
        {
            this.streamReader = streamReader;
            this.streamReader.BaseStream.Position = 0;
        }

        /// <summary>
        /// Read all data from stream.
        /// </summary>
        /// <returns>IList"FileCabinetRecord" with data from stream.</returns>
        public IList<FileCabinetStudent> ReadAll()
        {
            List<FileCabinetStudent> list = new List<FileCabinetStudent>();
            FileCabinetStudent record;
            string[] lineRecord;

            while (!this.streamReader.EndOfStream)
            {
                try
                {
                    record = new FileCabinetStudent();
                    lineRecord = this.streamReader.ReadLine().Split(", ");
                    record.Id = int.Parse(lineRecord[0], this.cultureInfo);
                    record.Gender = char.Parse(lineRecord[1]);
                    record.FirstName = lineRecord[2];
                    record.LastName = lineRecord[3];
                    record.DateOfBirth = DateTime.Parse(lineRecord[4]);
                    record.totalRating = short.Parse(lineRecord[5]);
                    record.University = lineRecord[6];
                    record.Faculty = lineRecord[7];
                    list.Add(record);
                }
                catch
                {
                    Console.WriteLine("Read csv exception.");
                }
            }

            return list;
        }
    }
}
