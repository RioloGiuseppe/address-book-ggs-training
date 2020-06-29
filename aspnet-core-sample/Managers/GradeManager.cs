using aspnet_core_sample.Models;
using aspnet_core_sample.Storages;
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
        protected virtual GradeStorage GradeStorage { get; private set; }
        protected virtual StudentStorage StudentStorage { get; private set; }
        public GradeManager(ILogger<GradeManager> logger, GradeStorage gradeStorage, StudentStorage studentStorage)
        {
            Logger = logger;
            GradeStorage = GradeStorage;
            StudentStorage = StudentStorage;
        }


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

        // add relation manager

        // add/remove relation Student <=> Grade
        // using storage classes

    }
}
