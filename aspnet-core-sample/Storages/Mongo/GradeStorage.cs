using aspnet_core_sample.Data;
using aspnet_core_sample.Models;
using aspnet_core_sample.Models.Mongo;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_sample.Storages.Mongo
{
    public class GradeStorage : IGradeStorage
    {
        protected virtual ILogger<GradeStorage> Logger { get; private set; }
        protected virtual MongoDbClient Database { get; private set; }
        public GradeStorage(ILogger<GradeStorage> logger, MongoDbClient mongoDbClient)
        {
            Logger = logger;
            Database = mongoDbClient;
        }

        public async Task Create(Grade grade, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Database.Grades.InsertOneAsync(new MongoGrade()
            {
                GradeName = grade.GradeName,
                Section = grade.Section,
            });
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                await Database.Grades.DeleteOneAsync(c => c.GradeId == id);
                Logger.LogInformation($"Removed grade with id: {id}");
                return true;
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return false;
            }
        }

        public async Task Edit(int id, Grade grade, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                await Database.Grades.ReplaceOneAsync(c => c.GradeId == id, new MongoGrade()
                {
                    GradeName = grade.GradeName,
                    Section = grade.Section,
                });
                Logger.LogInformation($"Removed grade with id: {id}");
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
            }
        }

        public async Task<Grade> Get(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var grade = (await Database.Grades.Find(c => c.GradeId == id)
                    .ToListAsync())
                    .Cast<Grade>()
                    .FirstOrDefault();
                Logger.LogInformation($"Got grade with id: {id}");
                return grade;
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return null;
            }
        }

        public async Task<List<Grade>> List(int skip = 0, int? take = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var grades = (await Database.Grades.Find(new BsonDocument())
                    .Skip(skip)
                    .Limit(take)
                    .ToListAsync())
                    .Cast<Grade>()
                    .ToList();
                Logger.LogInformation($"Listed grade");
                return grades;
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return null;
            }
        }

        public Task Update(int id, Grade grade, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
