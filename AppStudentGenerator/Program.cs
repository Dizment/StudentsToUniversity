using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using StudentsToUniversity;

namespace AppStudentGenerator
{
    /// <summary>
    /// Class reads the parameters and generate records.
    /// </summary>
    public static class Program
    {
        private static List<FileCabinetStudent> students = new List<FileCabinetStudent>();
        private static string outputType = null;
        private static string path = null;
        private static int recordsAmount = default;
        private static int startId = default;

        static void Main(string[] args)
        {
            SetParam(args, ref outputType, ref path, ref recordsAmount, ref startId);

            if (outputType != null && path != null && recordsAmount != default && startId != default)
            {
                for (int i = startId; i <= recordsAmount + startId; i++)
                {
                    students.Add(FileCabinetGenerateStudent.GenerateRecord(i));
                }

                Export();

                Console.WriteLine("Export completed successfully.");
            }
            else
            {
                Console.WriteLine("Incorrect parameters.");
            }
        }

        private static void Export()
        {
            if (outputType == "CSV")
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.ASCII))
                {
                    FileCabinetGenerateSnapshot csv = new FileCabinetGenerateSnapshot();
                    csv.Records = students;
                    csv.SaveToCsv(streamWriter);
                }
            }

            if (outputType == "XML")
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.ASCII))
                {
                    FileCabinetGenerateSnapshot xml = new FileCabinetGenerateSnapshot();
                    xml.Records = students;
                    xml.SaveToXml(streamWriter);
                }
            }
        }

        private static void SetParam(string[] args, ref string outputTypeRes, ref string outputRes, ref int recordsAmountRes, ref int startIdRes)
        {
            string outputType = "--output-type=";
            string shortoutputType = "-t";
            string output = "--output=";
            string shortoutput = "-o";
            string recordsAmount = "--records-amount=";
            string shortrecordAmount = "-a";
            string startId = "--start-id=";
            string shortstartId = "-i";

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith(outputType) || args[i].StartsWith(shortoutputType))
                    {
                        if (args[i + 1].ToUpper() == "XML")
                        {
                            outputTypeRes = "XML";
                            i++;
                        }
                        else if (args[i + 1].ToUpper() == "CSV")
                        {
                            outputTypeRes = "CSV";
                            i++;
                        }
                        else if (args[i][outputType.Length..].ToUpper() == "XML")
                        {
                            outputTypeRes = "XML";
                        }
                        else if (args[i][outputType.Length..].ToUpper() == "CSV")
                        {
                            outputTypeRes = "CSV";
                        }
                        else
                        {
                            throw new ArgumentException("Incorrect value '--output-type'");
                        }

                        continue;
                    }

                    if (args[i].StartsWith(output))
                    {
                        if (!Path.HasExtension(args[i][output.Length..]))
                        {
                            throw new ArgumentException("Incorrect value '--output'");
                        }
                        else
                        {
                            outputRes = args[i][output.Length..];
                        }

                        continue;
                    }

                    if (args[i].StartsWith(shortoutput))
                    {
                        if (!Path.HasExtension(args[i + 1]))
                        {
                            throw new ArgumentException("Incorrect value '-o'");
                        }
                        else
                        {
                            outputRes = args[i + 1];
                            i++;
                        }

                        continue;

                    }

                    if (args[i].StartsWith(recordsAmount))
                    {
                        if (!int.TryParse(args[i][recordsAmount.Length..], out recordsAmountRes))
                        {
                            throw new ArgumentException("Incorrect value '--records-amount'");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (args[i].StartsWith(shortrecordAmount))
                    {
                        if (!int.TryParse(args[i + 1], out recordsAmountRes))
                        {
                            throw new ArgumentException("Incorrect value '--records-amount'");
                        }
                        else
                        {
                            i++;
                            continue;
                        }
                    }

                    if (args[i].StartsWith(startId))
                    {
                        if (!int.TryParse(args[i][startId.Length..], out startIdRes))
                        {
                            throw new ArgumentException("Incorrect value '--startId'");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (args[i].StartsWith(shortstartId))
                    {
                        if (!int.TryParse(args[i + 1], out startIdRes))
                        {
                            throw new ArgumentException("Incorrect value '-I'");
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
