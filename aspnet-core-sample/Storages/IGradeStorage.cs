using aspnet_core_sample.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_sample.Storages
{
    public interface IGradeStorage
    {
        Task Create(Grade grade, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task Edit(int id, Grade grade, CancellationToken cancellationToken = default);
        Task<Grade> Get(int id, CancellationToken cancellationToken = default);
        Task<List<Grade>> List(int skip = 0, int? take = null, CancellationToken cancellationToken = default);
        Task Update(int id, Grade grade, CancellationToken cancellationToken = default);
    }
}