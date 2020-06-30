using aspnet_core_sample.Data;
using aspnet_core_sample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_sample.Storages
{
    public class GradeStorage : IGradeStorage
    {
        protected virtual ILogger<GradeStorage> Logger { get; private set; }
        protected virtual ApplicationDbContext Context { get; private set; }
        public GradeStorage(ILogger<GradeStorage> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<List<Grade>> List(int skip = 0, int? take = null, CancellationToken cancellationToken = default)
        {
            if (take == null)
            {
                return await Context.Grades.OrderBy(o => o.GradeId).Skip(skip).ToListAsync();
            }
            return await Context.Grades.OrderBy(o => o.GradeId).Skip(skip).Take(take.Value).ToListAsync(cancellationToken);
        }

        public async Task<Grade> Get(int id, CancellationToken cancellationToken = default)
        {

            var grade = await Context.Grades
                .Include(g => g.Students)
                .FirstOrDefaultAsync(m => m.GradeId == id, cancellationToken);
            return grade;
        }

        public async Task Create(Grade grade, CancellationToken cancellationToken = default)
        {
            await Context.Grades.AddAsync(grade, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(int id, Grade grade, CancellationToken cancellationToken = default)
        {
            if (id != grade.GradeId)
            {
                throw new Exception("Invalied ID");
            }
            try
            {
                var grad = await Context.Grades.FirstOrDefaultAsync(x => x.GradeId == id);
                if (grad == null) throw new Exception("Not Found");
                grad.GradeName = grade.GradeName;
                grad.Students = grade.Students;
                await Context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Exists(grade.GradeId, cancellationToken))
                {
                    throw new Exception("Not Found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var grade = await Context.Grades.FindAsync(id, cancellationToken);
            if (grade != null)
            {
                Context.Grades.Remove(grade);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            return await Context.Grades.AnyAsync(e => e.GradeId == id, cancellationToken);
        }
    }
}
