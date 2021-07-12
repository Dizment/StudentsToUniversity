using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using StudentsToUniversity;

namespace StudentsToUniversity
{
    public class FileCabinetSnapshot
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
            var csv = new FileCabinetStudentCsvWriter(streamWriter);
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
            var csv = new FileCabinetStudentXmlWriter(writer);
            foreach (var item in this.records)
            {
                csv.Write(item);
            }

            writer.WriteEndElement();
            writer.Close();
        }

        /// <summary>
        /// Load stream from csv.
        /// </summary>
        /// <param name="streamReader">Stream reader.</param>
        public void LoadFromCsv(StreamReader streamReader)
        {
            FileCabinetStudentReaderCsv fileCabinetRecordCsvReader = new FileCabinetStudentReaderCsv(streamReader);
            this.records = new List<FileCabinetStudent>(fileCabinetRecordCsvReader.ReadAll());
        }

        /// <summary>
        /// Load stream from xml.
        /// </summary>
        /// <param name="streamReader">stream.</param>
        public void LoadFromXml(StreamReader streamReader)
        {
            FileCabinetStudentReaderXml fileCabinetRecordXmlReader = new FileCabinetStudentReaderXml(streamReader);
            this.records = new List<FileCabinetStudent>(fileCabinetRecordXmlReader.ReadAll());
        }
    }
}
