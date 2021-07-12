using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity
{
    public interface IFileCabinetService
    {
        /// <summary>
        /// Insert students.
        /// </summary>
        /// <param name="record">Record.</param>
        /// <returns>value for validation.</returns>
        void Insert(FileCabinetStudent record);

        /// <summary>
        /// The method by which we can get list of the students.
        /// </summary>
        /// <returns>List of records.</returns>
        IEnumerable<FileCabinetStudent> GetRecords();

        /// <summary>
        /// Restore data from snapshot.
        /// </summary>
        /// <param name="fileCabinetServiceSnapshot">Snapshot instance.</param>
        void Restore(FileCabinetSnapshot fileCabinetServiceSnapshot);

        /// <summary>
        /// Returns file cabinet service snapshot instance.
        /// </summary>
        /// <returns>File cabinet service snapshot instance.</returns>
        FileCabinetSnapshot MakeSnapshot(string typeStudent);

        /// <summary>
        /// Distributes students to universities and faculties according to their total rating.
        /// </summary>
        void Distribute();
    }
}
