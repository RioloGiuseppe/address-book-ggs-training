using aspnet_core_sample.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_sample.Storages
{
    public class StudentStorage
    {
        protected virtual ILogger<StudentStorage> Logger { get; private set; }
        protected virtual ApplicationDbContext Context { get; private set; }
        public StudentStorage(ILogger<StudentStorage> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }
    }
}
