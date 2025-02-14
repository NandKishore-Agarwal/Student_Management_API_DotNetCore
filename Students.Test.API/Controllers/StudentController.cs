using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Test.Services.IServices;

namespace Hiring.Test.API.Controllers
{
    /// <summary>
    /// StudentController class containing Api's for Student departments.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="studentService">studentService.</param>
        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            this._logger = logger;
            this._studentService = studentService;
        }

        /// <summary>
        /// Get Student details by Student Id.
        /// </summary>
        /// <param name="studentid">studentid.</param>
        /// <returns>student details.</returns>
        [HttpGet]
        [Route("api/GetStudentDetails/{studentid}")]
        public async Task<ActionResult> Get(int studentid)
        {
            if (studentid <= 0)
            {
                return this.Ok("Please enter Valid student Id");
            }

            try
            {
                this._logger.LogInformation("Calling GetStudentbyIdAsync method");
                var student = await this._studentService.GetStudentbyIdAsync(studentid).ConfigureAwait(false);
                if (student != null)
                {
                    return this.Ok(student);
                }
                else
                {
                    return this.Ok(this.NotFound("Record not found"));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :"+ ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }

        /// <summary>
        /// Get average grade by departmet Id.
        /// </summary>
        /// <param name="departmentid">departmentid.</param>
        /// <returns>average grade.</returns>
        [HttpGet]
        [Route("api/GetAverage/{departmentid}")]
        public async Task<ActionResult> GetAverage(int departmentid)
        {
            if (departmentid < 0)
            {
                return this.Ok("Please enter Valid department Id");
            }

            try
            {
                this._logger.LogInformation("Calling GetAverageGradeAsync method");
                float average = await this._studentService.GetAverageGradeAsync(departmentid).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(average.ToString()))
                {
                    return this.Ok(average);
                }
                else
                {
                    return this.Ok(this.NotFound("Record not found"));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.NotFound("Record not found"));
            }
        }

        /// <summary>
        /// Get all department and their student count.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        [Route("api/Gettotalstudent")]
        public async Task<ActionResult> Gettotalstudent()
        {
            try
            {
                this._logger.LogInformation("Calling GetStudentCountAsync method");
                return this.Ok(await this._studentService.GetStudentCountAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }

        /// <summary>
        /// Get all departments, these will be used for data population in dropdown.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        [Route("api/GetDepartments")]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                this._logger.LogInformation("Calling GetDepartmentsAsync method");
                return this.Ok(await this._studentService.GetDepartmentsAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }

        /// <summary>
        /// Get all students by department.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        [Route("api/GetStudentDepartments")]
        public async Task<ActionResult> GetStudentDepartments()
        {
            try
            {
                this._logger.LogInformation("Calling GetStudentDepartmentsAsync method");
                return this.Ok(await this._studentService.GetStudentDepartmentsAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }

        /// <summary>
        /// Get all students by departmentid.
        /// </summary>
        /// <param name="departmentid">departmentid.</param>
        /// <returns>.</returns>
        [HttpGet]
        [Route("api/GetStudentbyDepartmentsidAsync/{departmentid}")]
        public async Task<ActionResult> GetStudentbyDepartmentsidAsync(int departmentid)
        {
            try
            {
                this._logger.LogInformation("Calling GetStudentbyDepartmentsidAsync method");
                var result = await this._studentService.GetStudentbyDepartmentsidAsync(departmentid).ConfigureAwait(false);
                if (result.Any())
                {
                    return this.Ok(result);
                }
                else
                {
                    return this.Ok(this.NotFound("Record not found"));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }

        /// <summary>
        /// Save new student details.
        /// </summary>
        /// <param name="student">student.</param>
        /// <returns>.</returns>
        [HttpPost]
        [Route("api/SaveStudent")]
        public async Task<ActionResult> SaveStudent([FromBody] Student student)
        {
            try
            {
                this._logger.LogInformation("Calling SaveStudents method");
                return this.Ok(await this._studentService.SaveStudents(student).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error :" + ex.StackTrace);
                return this.Ok(this.BadRequest("Could not fetch data"));
            }
        }
    }
}
