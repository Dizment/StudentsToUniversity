using System;
using System.Collections.Generic;
using System.IO;
using StudentsToUniversity;
using System.Text;
using System.Globalization;

namespace AppStudentGenerator
{
    /// <summary>
    /// File Cabinet Record Csv Writer.
    /// </summary>
    public class FileCabinetGenerateCsvWriter
    {
        private readonly TextWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetGenerateCsvWriter"/> class.
        /// </summary>
        /// <param name="textWriter">Text writer.</param>
        public FileCabinetGenerateCsvWriter(TextWriter textWriter)
        {
            this.writer = textWriter;
        }

        /// <summary>
        /// Write record to stream.
        /// </summary>
        /// <param name="student">The record.</param>
        public void Write(FileCabinetStudent student)
        {
            if (student is null)
            {
                throw new ArgumentException($"{nameof(student)}");
            }

            string line = $"{student.Id}, {student.Gender}, {student.FirstName}, {student.LastName}, {student.DateOfBirth.ToString("dd/MM/yyyy", new CultureInfo("en-US"))}, {student.totalRating}, {student.University}, {student.Faculty}";
            this.writer.WriteLine(line);
        }
    }
}