using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_sample.Managers;
using aspnet_core_sample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnet_core_sample.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomGradeApiController : ControllerBase
    {
        protected virtual ILogger<CustomGradeApiController> Logger { get; private set; }
        protected virtual GradeManager GradeManager { get; private set; }
        public CustomGradeApiController(ILogger<CustomGradeApiController> logger, GradeManager manager)
        {
            Logger = logger;
            GradeManager = manager;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Student>>> ListStudents(int skip = 0, int? take = null)
        {
            return await GradeManager.ListStudent(skip, take);
        }
    }
}
