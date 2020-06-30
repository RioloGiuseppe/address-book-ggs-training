using aspnet_core_sample.Models;
using aspnet_core_sample.Storages;
using aspnet_core_sample.Storages.ER;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_sample.Managers
{
    public class GradeManager
    {
        protected virtual ILogger<GradeManager> Logger { get; private set; }
        protected virtual IGradeStorage GradeStorage { get; private set; }
        protected virtual IStudentStorage StudentStorage { get; private set; }
        public GradeManager(ILogger<GradeManager> logger, IGradeStorage gradeStorage, IStudentStorage studentStorage)
        {
            Logger = logger;
            GradeStorage = gradeStorage;
            StudentStorage = studentStorage;
        }

        #region CRUD Student

        public async Task CreateStudent(Student student, CancellationToken cancellationToken = default)
            => await StudentStorage.Create(student, cancellationToken);
        public async Task<bool> DeleteStudent(int id, CancellationToken cancellationToken = default)
            => await StudentStorage.Delete(id, cancellationToken);
        public async Task EditStudent(int id, Student student, CancellationToken cancellationToken = default)
            => await StudentStorage.Edit(id, student, cancellationToken);
        public async Task<Student> GetStudent(int id, CancellationToken cancellationToken = default)
            => await StudentStorage.Get(id, cancellationToken);
        public async Task<List<Student>> ListStudent(int skip = 0, int? take = null, CancellationToken cancellationToken = default)
            => await StudentStorage.List(skip, take, cancellationToken);

        #endregion

        #region CRUD Grade

        public async Task CreateGrade(Grade Grade, CancellationToken cancellationToken = default)
            => await GradeStorage.Create(Grade, cancellationToken);
        public async Task<bool> DeleteGrade(int id, CancellationToken cancellationToken = default)
            => await GradeStorage.Delete(id, cancellationToken);
        public async Task EditGrade(int id, Grade Grade, CancellationToken cancellationToken = default)
            => await GradeStorage.Edit(id, Grade, cancellationToken);
        public async Task<Grade> GetGrade(int id, CancellationToken cancellationToken = default)
            => await GradeStorage.Get(id, cancellationToken);
        public async Task<List<Grade>> ListGrade(int skip = 0, int? take = null, CancellationToken cancellationToken = default)
            => await GradeStorage.List(skip, take, cancellationToken);

        #endregion

        // add relation manager

        // add/remove relation Student <=> Grade
        // using storage classes

    }
}
