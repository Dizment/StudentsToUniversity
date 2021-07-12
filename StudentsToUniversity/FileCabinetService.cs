using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using StudentsToUniversity.ConfigJson;
using Microsoft.Extensions.Configuration;

namespace StudentsToUniversity
{
    public class FileCabinetService : IFileCabinetService
    {
        private List<FileCabinetStudent> students = new List<FileCabinetStudent>();
        private List<FileCabinetStudent> studentsWithUniversity = new List<FileCabinetStudent>();
        private static readonly string[][] University = { new string[] { "BNTU", "robots", "energy" }, new string[] { "BSUIR", "ksis", "radiotech", "informtech" }, new string[] { "BSU", "radiophys", "fpmi", "mechmat" } };


        public void Insert(FileCabinetStudent student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
        }

        public IEnumerable<FileCabinetStudent> GetRecords()
        {
            foreach (var record in new ReadOnlyCollection<FileCabinetStudent>(this.students))
            {
                yield return record;
            }
        }

        /// <summary>
        /// Returns file cabinet service snapshot instance.
        /// </summary>
        /// <returns>File cabinet service snapshot instance.</returns>
        public FileCabinetSnapshot MakeSnapshot(string typeStudent)
        {
            FileCabinetSnapshot fileCabinetServiceSnapshot = new FileCabinetSnapshot();
            if (typeStudent.Equals("university"))
            {
                fileCabinetServiceSnapshot.Records = this.studentsWithUniversity;
            }

            if (typeStudent.Equals("all"))
            {
                fileCabinetServiceSnapshot.Records = this.students;
            }

            return fileCabinetServiceSnapshot;
        }

        /// <summary>
        /// Restore data from snapshot.
        /// </summary>
        /// <param name="fileCabinetServiceSnapshot">Snapshot instance.</param>
        public void Restore(FileCabinetSnapshot fileCabinetServiceSnapshot)
        {
            if (fileCabinetServiceSnapshot is null)
            {
                throw new ArgumentException("Snapshot is null", nameof(fileCabinetServiceSnapshot));
            }

            foreach (var record in fileCabinetServiceSnapshot.Records)
            {
                int index = this.students.IndexOf(record);
                if (students.Find(student => student.Id == record.Id) != null)
                {
                    record.Id = students.Count + 1;
                }

                if (index < 0)
                {
                    this.students.Add(record);
                }
                else
                {
                    this.students[index] = record;
                }
            }
        }

        /// <summary>
        /// Distributes students to universities and faculties according to their total rating.
        /// </summary>
        public void Distribute()
        {
            students = students.OrderBy(o => o.totalRating).ToList();
            students.Reverse();

            IConfiguration config = new ConfigurationBuilder()
                      .SetBasePath("C:/Users/Терминатор/source/repos/StudentsToUniversity/StudentsToUniversity/Properties")
                      .AddJsonFile("universitys-rules.json", true, true)
                      .Build();

            UniversityJson rules = (UniversityJson)ConfigurationBinder.Get(config, typeof(UniversityJson));

            var bsuRadiophys = rules.BSU.RadioPhys.Place;
            var bsuFpmi = rules.BSU.Fpmi.Place;
            var bsuMechMat = rules.BSU.MechMat.Place;
            var bsuirKsis = rules.BSUIR.Ksis.Place;
            var bsuirInformTech = rules.BSUIR.InformTech.Place;
            var bsuirRadioTech = rules.BSUIR.RadioTech.Place;
            var bntuEnergy = rules.BNTU.Energy.Place;
            var bntuRobots = rules.BNTU.Energy.Place;

            foreach (var student in students)
            {
                string university;
                string faculty;

                RandomUniversity(out university, out faculty);

                if (University[0][0].Equals(university))
                {
                    if (University[0][1].Equals(faculty) && bntuRobots != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bntuRobots--;
                    }

                    if (University[0][2].Equals(faculty) && bntuEnergy != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bntuEnergy--;
                    }
                }

                if (University[1][0].Equals(university))
                {
                    if (University[1][1].Equals(faculty) && bsuirKsis != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuirKsis--;
                    }

                    if (University[1][2].Equals(faculty) && bsuirRadioTech != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuirRadioTech--;
                    }

                    if (University[1][3].Equals(faculty) && bsuirInformTech != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuirInformTech--;
                    }
                }

                if (University[2][0].Equals(university))
                {
                    if (University[2][1].Equals(faculty) && bsuRadiophys != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuRadiophys--;
                    }

                    if (University[2][2].Equals(faculty) && bsuFpmi != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuFpmi--;
                    }

                    if (University[2][3].Equals(faculty) && bsuMechMat != 0)
                    {
                        student.University = university;
                        student.Faculty = faculty;
                        studentsWithUniversity.Add(student);
                        bsuMechMat--;
                    }
                }
            }

            Console.WriteLine($"{studentsWithUniversity.Count} students out of {students.Count} were successfully distributed.");
        }

        public static void RandomUniversity(out string university, out string faculty)
        {
            Random rand = new Random();
            int randUniversity = rand.Next(0, 3);
            int randFaculty = rand.Next(1, University[randUniversity].Length);

            university = University[randUniversity][0];
            faculty = University[randUniversity][randFaculty];
        }
    }
}
