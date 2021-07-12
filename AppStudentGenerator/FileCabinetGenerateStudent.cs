using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using StudentsToUniversity;

namespace AppStudentGenerator
{
    public class FileCabinetGenerateStudent
    {
        private static Random rand = new Random();
        private static string[][] University = { new string[]{ "BNTU", "robots", "energy" }, new string[] { "BSUIR", "ksis", "radiotech", "informtech" }, new string[] { "BSU", "radiophys", "fpmi", "mechmat" } };

        /// <summary>
        /// Generate one student.
        /// </summary>
        /// <param name="id">Number of student.</param>
        /// <returns>One student with new properties.</returns>
        public static FileCabinetStudent GenerateRecord(int id)
        {
            FileCabinetStudent student = new FileCabinetStudent();

            student.Id = id;
            student.Gender = RandomChar();
            student.FirstName = RandomString(4, 20);
            student.LastName = RandomString(4, 20);
            student.DateOfBirth = RandomDate(new DateTime(1995, 1, 1));
            student.totalRating = RandomShort();
            student.University = "-";
            student.Faculty = "-";

            Console.Write("#" + student.Id + ", ");
            Console.Write(student.Gender == 'm' ? "male, " : "female, ");
            Console.Write(student.FirstName + ", ");
            Console.Write(student.LastName + ", ");
            Console.Write(student.DateOfBirth.ToString("yyyy-MMM-dd", CultureInfo.CurrentCulture) + ", ");
            Console.Write(student.University + ", ");
            Console.Write(student.Faculty);
            Console.WriteLine();

            return student;
        }

        public static void RandomUniversity(ref FileCabinetStudent student)
        {
            int randUniversity = rand.Next(0, 3);
            int randFaculty = rand.Next(1, University[randUniversity].Length);

            student.University = University[randUniversity][0];
            student.Faculty = University[randUniversity][randFaculty];
        }

        /// <summary>
        /// Method for generate string in input interval.
        /// </summary>
        /// <param name="minLenght">Min lenght of string.</param>
        /// <param name="maxLenght">Max lenght of string.</param>
        /// <returns>Random string.</returns>
        public static string RandomString(int minLenght, int maxLenght)
        {
            int stringLenght = rand.Next(minLenght, maxLenght);
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string result = string.Empty;

            for (int i = 0; i < stringLenght; i++)
            {
                result += letters[rand.Next(0, letters.Length - 1)];
            }

            return char.ToUpper(result[0]) + result[1..];
        }

        /// <summary>
        /// Method for generate char type.
        /// </summary>
        /// <returns>Random char value 'f' or 'm'.</returns>
        public static char RandomChar()
        {
            if (rand.Next(10) % 2 == 0)
            {
                return 'f';
            }
            else
            {
                return 'm';
            }
        }

        /// <summary>
        /// Method for generate short type.
        /// </summary>
        /// <returns>Random short value.</returns>
        public static short RandomShort()
        {
            return (short)rand.Next(1, 400);
        }

        /// <summary>
        /// Method for generate date.
        /// </summary>
        /// <param name="start">Min value of date.</param>
        /// <returns>Random date.</returns>
        public static DateTime RandomDate(DateTime start)
        {
            int range = (new DateTime(2003, 1, 1) - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}
