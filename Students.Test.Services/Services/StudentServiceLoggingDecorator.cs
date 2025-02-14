using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Students.Test.Model.ViewModels;
using Students.Test.Services.IServices;

namespace Students.Test.Services.Services
{
    /// <summary>
    /// StudentServiceLoggingDecorator class containing methods for Logging in student service.
    /// </summary>
    public class StudentServiceLoggingDecorator : IStudentService
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentServiceLoggingDecorator> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentServiceLoggingDecorator"/> class.
        /// </summary>
        /// <param name="studentService">studentService.</param>
        /// <param name="logger">logger.</param>
        public StudentServiceLoggingDecorator(IStudentService studentService, ILogger<StudentServiceLoggingDecorator> logger)
        {
            this._studentService = studentService;
            this._logger = logger;
        }

        /// <inheritdoc/>
        public async Task<Student> GetStudentbyIdAsync(int studentid)
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            Student student = await this._studentService.GetStudentbyIdAsync(studentid).ConfigureAwait(false);

            var jsonStudent = JsonConvert.SerializeObject(student);
            this._logger.LogInformation(jsonStudent);

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return student;
        }

        /// <inheritdoc/>
        public async Task<float> GetAverageGradeAsync(int departmentid)
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            float average = await this._studentService.GetAverageGradeAsync(departmentid).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(average.ToString())){
                this._logger.LogInformation("Average Grade : " + average + "department :" + departmentid);
            }
            else
            {
                this._logger.LogInformation("No record Found");
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return average;
        }

        /// <inheritdoc/>
        public async Task<List<DepartmentStudentViewModel>> GetStudentCountAsync()
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            List<DepartmentStudentViewModel> departmentViewModels = await this._studentService.GetStudentCountAsync().ConfigureAwait(false);

            foreach (var department in departmentViewModels)
            {
                var jsonStudent = JsonConvert.SerializeObject(department);
                this._logger.LogInformation(jsonStudent);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return departmentViewModels;
        }

        /// <inheritdoc/>
        public async Task<List<DropdownViewModel>> GetDepartmentsAsync()
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            List<DropdownViewModel> dropdownViewModel = await this._studentService.GetDepartmentsAsync().ConfigureAwait(false);

            foreach (var department in dropdownViewModel)
            {
                var jsonStudent = JsonConvert.SerializeObject(department);
                this._logger.LogInformation(jsonStudent);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return dropdownViewModel;
        }

        /// <inheritdoc/>
        public async Task<List<DepartmentViewModel>> GetStudentDepartmentsAsync()
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            List<DepartmentViewModel> departmentViewModels = await this._studentService.GetStudentDepartmentsAsync().ConfigureAwait(false);

            foreach (var department in departmentViewModels)
            {
                var jsonStudent = JsonConvert.SerializeObject(department);
                this._logger.LogInformation(jsonStudent);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return departmentViewModels;
        }

        /// <inheritdoc/>
        public async Task<List<DepartmentViewModel>> GetStudentbyDepartmentsidAsync(int departmentid)
        {
            this._logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            List<DepartmentViewModel> departmentViewModels = await this._studentService.GetStudentbyDepartmentsidAsync(departmentid).ConfigureAwait(false);

            if (departmentViewModels.Any())
            {
                foreach (var department in departmentViewModels)
                {
                    var jsonStudent = JsonConvert.SerializeObject(department);
                    this._logger.LogInformation(jsonStudent);
                }
            }
            else
            {
                this._logger.LogInformation("Record not found");
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            this._logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return departmentViewModels;
        }

        /// <inheritdoc/>
        public Task<List<Student>> SaveStudents(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
