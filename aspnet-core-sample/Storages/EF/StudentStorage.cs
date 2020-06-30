using aspnet_core_sample.Data;
using aspnet_core_sample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace aspnet_core_sample.Storages.ER
{
    public class StudentStorage : IStudentStorage
    {
        protected virtual ILogger<StudentStorage> Logger { get; private set; }
        protected virtual ApplicationDbContext Context { get; private set; }
        public StudentStorage(ILogger<StudentStorage> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<List<Student>> List(int skip = 0, int? take = null, CancellationToken cancellationToken = default)
        {
            if (take == null)
            {
                return await Context.Students.OrderBy(o => o.Id).Skip(skip).ToListAsync();
            }
            return await Context.Students.OrderBy(o => o.Id).Skip(skip).Take(take.Value).ToListAsync(cancellationToken);
        }

        public async Task<Student> Get(int id, CancellationToken cancellationToken = default)
        {

            var student = await Context.Students
                .Include(s => s.CurrentGrade)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            return student;
        }

        public async Task Create(Student student, CancellationToken cancellationToken = default)
        {
            await Context.Students.AddAsync(student, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(int id, Student student, CancellationToken cancellationToken = default)
        {
            if (id != student.Id)
            {
                throw new Exception("Invalied ID");
            }
            try
            {
                var stud = await Context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (stud == null) throw new Exception("Not Found");
                stud.Name = student.Name;
                stud.CurrentGradeId = student.CurrentGradeId;
                await Context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Exists(student.Id, cancellationToken))
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
            var student = await Context.Students.FindAsync(id);
            if (student != null)
            {
                Context.Students.Remove(student);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            return await Context.Students.AnyAsync(e => e.Id == id, cancellationToken);
        }
    }
}
