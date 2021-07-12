using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using StudentsToUniversity;

namespace AppStudentGenerator
{
    public class FileCabinetGenerateXmlWriter
    {
        private readonly XmlWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetGenerateXmlWriter"/> class.
        /// </summary>
        /// <param name="xmlWriter">Text writer.</param>
        public FileCabinetGenerateXmlWriter(XmlWriter xmlWriter)
        {
            this.writer = xmlWriter;
        }

        /// <summary>
        /// Write record to stream.
        /// </summary>
        /// <param name="record">The record.</param>
        public void Write(FileCabinetStudent record)
        {
            if (record is null)
            {
                throw new ArgumentException($"{nameof(record)}");
            }

            this.writer.WriteStartElement("student");
            this.writer.WriteAttributeString("id", $"{record.Id}");
            this.writer.WriteStartElement("Id");
            this.writer.WriteString($"{record.Id}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("Gender");
            this.writer.WriteString($"{record.Gender}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("firstname");
            this.writer.WriteString($"{record.FirstName}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("lastname");
            this.writer.WriteString($"{record.LastName}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("dateOfBirth");
            this.writer.WriteString($"{record.DateOfBirth.ToString("dd/MM/yyyy", new CultureInfo("en-US"))}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("totalrating");
            this.writer.WriteString($"{record.totalRating}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("university");
            this.writer.WriteString($"{record.University}");
            this.writer.WriteEndElement();
            this.writer.WriteStartElement("faculty");
            this.writer.WriteString($"{record.Faculty}");
            this.writer.WriteEndElement();
            this.writer.WriteEndElement();
        }
    }
}
