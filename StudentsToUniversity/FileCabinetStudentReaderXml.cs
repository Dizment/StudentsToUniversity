using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace StudentsToUniversity
{
    class FileCabinetStudentReaderXml
    {
        private readonly StreamReader streamReader;
        private readonly List<FileCabinetStudent> students = new List<FileCabinetStudent>();

        public FileCabinetStudentReaderXml(StreamReader streamReader)
        {
            this.streamReader = streamReader;
            this.streamReader.BaseStream.Position = 0;
        }

        /// <summary>
        /// Read all data from xml file.
        /// </summary>
        /// <returns>list of records.</returns>
        public IList<FileCabinetStudent> ReadAll()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            FileCabinetStudent student = new FileCabinetStudent();
            int a = 0;
            using (XmlReader reader = XmlReader.Create(streamReader, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        string obj = reader.GetValueAsync().Result;

                        switch (a)
                        {
                            case 0:
                                student.Id = int.Parse(obj);
                                a++;
                                break;
                            case 1:
                                student.Gender = char.Parse(obj);
                                a++;
                                break;
                            case 2:
                                student.FirstName = obj;
                                a++;
                                break;
                            case 3:
                                student.LastName = obj;
                                a++;
                                break;
                            case 4:
                                student.DateOfBirth = DateTime.Parse(obj);
                                a++;
                                break;
                            case 5:
                                student.totalRating = short.Parse(obj);
                                a++;
                                break;
                            case 6:
                                student.University = obj;
                                a++;
                                break;
                            case 7:
                                student.Faculty = obj;
                                a = 0;
                                students.Add(student);
                                student = new FileCabinetStudent();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return this.students;
        }
    }
}
