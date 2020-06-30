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

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Student>>> ListStudents(int skip = 0, int? take = null)
        {
            return await GradeManager.ListStudent(skip, take);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await GradeManager.GetStudent(id);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task EditStudent(int id, Student student)
        {
            await GradeManager.EditStudent(id, student);
        }

        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            return await GradeManager.DeleteStudent(id);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task CreateStudent(Student student)
        {
            await GradeManager.CreateStudent(student);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Grade>>> ListGrades(int skip = 0, int? take = null)
        {
            return await GradeManager.ListGrade(skip, take);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            return await GradeManager.GetGrade(id);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task EditGrade(int id, Grade grade)
        {
            await GradeManager.EditGrade(id, grade);
        }

        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteGrade(int id)
        {
            return await GradeManager.DeleteGrade(id);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task CreateGrade(Grade grade)
        {
            await GradeManager.CreateGrade(grade);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task AddStudent(AddStudentToGradeModel model)
        {
            await GradeManager.AddStudent(model);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task RemoveStudent(AddStudentToGradeModel model)
        {
            await GradeManager.RemoveStudent(model);
        }
    }
}
