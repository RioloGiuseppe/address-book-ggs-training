using aspnet_core_sample.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_sample.Storages
{
    public interface IStudentStorage
    {
        Task Create(Student student, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task Edit(int id, Student student, CancellationToken cancellationToken = default);
        Task<Student> Get(int id, CancellationToken cancellationToken = default);
        Task<List<Student>> List(int skip = 0, int? take = null, CancellationToken cancellationToken = default);
    }
}