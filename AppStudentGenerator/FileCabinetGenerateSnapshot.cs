using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using StudentsToUniversity;

namespace AppStudentGenerator
{
    /// <summary>
    /// Class include methods for writting data.
    /// </summary>
    public class FileCabinetGenerateSnapshot
    {
        private IEnumerable<FileCabinetStudent> records;

        /// <summary>
        /// Gets or sets file cabinet records.
        /// </summary>
        /// <value>
        /// File cabinet records.
        /// </value>
        public IEnumerable<FileCabinetStudent> Records
        {
            get
            {
                return this.records;
            }

            set
            {
                this.records = value;
            }
        }

        /// <summary>
        /// Save stream to csv.
        /// </summary>
        /// <param name="streamWriter">Stream writer.</param>
        public void SaveToCsv(StreamWriter streamWriter)
        {
            var csv = new FileCabinetGenerateCsvWriter(streamWriter);
            foreach (var item in this.records)
            {
                csv.Write(item);
            }
        }

        public void SaveToXml(StreamWriter streamWriter)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = Encoding.ASCII;
            XmlWriter writer = XmlWriter.Create(streamWriter, xmlWriterSettings);
            writer.WriteStartElement("students");
            var csv = new FileCabinetGenerateXmlWriter(writer);
            foreach (var item in this.records)
            {
                csv.Write(item);
            }

            writer.WriteEndElement();
            writer.Close();
        }
    }
}
