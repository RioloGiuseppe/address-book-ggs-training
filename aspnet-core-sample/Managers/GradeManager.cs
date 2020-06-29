using aspnet_core_sample.Storages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
