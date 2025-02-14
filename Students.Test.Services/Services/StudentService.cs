using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Students.Test.Model.IRepository;
using Students.Test.Model.ViewModels;
using Students.Test.Services.IServices;

namespace Students.Test.Services.Services
{
    /// <summary>
    /// StudentService class containing methods for student service.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="studentRepository">studentRepository.</param>
        /// <param name="cacheProvider">cacheProvider.</param>
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        /// <inheritdoc />
        public async Task<Student> GetStudentbyIdAsync(int studentid)
        {
            Student student = null;
            student = await this._studentRepository.GetStudentAsync(studentid).ConfigureAwait(false);
            return student;
        }

        /// <inheritdoc />
        public async Task<float> GetAverageGradeAsync(int departmentid)
        {
            float averagescore = 0;
            averagescore = (await this._studentRepository.GetDepartmentAsync(departmentid).ConfigureAwait(false)).Average(x => x.Score);
            return averagescore;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentStudentViewModel>> GetStudentCountAsync()
        {
            List<DepartmentStudentViewModel> student = new List<DepartmentStudentViewModel>();
            student = (await this._studentRepository.GetAllStudentAsync().ConfigureAwait(false)).GroupBy(d => d.Department.Name).Select(d => new DepartmentStudentViewModel { Department = d.Key.ToString(), TotalStudent = d.Count() }).ToList();
            return student;
        }

        /// <inheritdoc />
        public async Task<List<DropdownViewModel>> GetDepartmentsAsync()
        {
            List<DropdownViewModel> dropdownModel = new List<DropdownViewModel>();
            dropdownModel = (await this._studentRepository.GetAllStudentAsync().ConfigureAwait(false)).GroupBy(x => new { x.Department.Id, x.Department.Name }).Select(x => new DropdownViewModel { Value = x.Key.Id, Text = x.Key.Name }).ToList();
            return dropdownModel;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentViewModel>> GetStudentDepartmentsAsync()
        {
            List<DepartmentViewModel> departmentViewModel = new List<DepartmentViewModel>();
            departmentViewModel = (await this._studentRepository.GetAllStudentAsync().ConfigureAwait(false)).GroupBy(x => new { x.Department.Id, x.Department.Name, x.Department.Location }).Select(x => new DepartmentViewModel { Id = x.Key.Id, Name = x.Key.Name, Location = x.Key.Location, Students = this.Getstudents(x.Key.Id) }).ToList();
            return departmentViewModel;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentViewModel>> GetStudentbyDepartmentsidAsync(int departmentid)
        {
            List<DepartmentViewModel> departmentViewModel = new List<DepartmentViewModel>();
            if (departmentid == 0)
            {
                departmentViewModel = (await this._studentRepository.GetAllStudentAsync().ConfigureAwait(false)).GroupBy(x => new { x.Department.Id, x.Department.Name, x.Department.Location }).Select(x => new DepartmentViewModel { Id = x.Key.Id, Name = x.Key.Name, Location = x.Key.Location, Students = this.Getstudents(x.Key.Id) }).ToList();
            }
            else
            {
                departmentViewModel = (await this._studentRepository.GetDepartmentAsync(departmentid).ConfigureAwait(false)).GroupBy(x => new { x.Department.Id, x.Department.Name, x.Department.Location }).Select(x => new DepartmentViewModel { Id = x.Key.Id, Name = x.Key.Name, Location = x.Key.Location, Students = this.Getstudents(x.Key.Id) }).ToList();
            }

            return departmentViewModel;
        }

        /// <inheritdoc />
        public async Task<List<Student>> SaveStudents(Student student)
        {
            List<Student> students = new List<Student>();
            students = (await this._studentRepository.SaveStudentAsync(student).ConfigureAwait(false)).ToList();
            return students;
        }

        /// <summary>
        /// getstudents.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>.</returns>
        private List<Student> Getstudents(int id)
        {
            var depart = this._studentRepository.GetAllStudent().Where(x => x.Department.Id == id).ToList();
            List<Student> students = depart.Select(x => new Student { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Score = x.Score }).ToList();
            return students;
        }
    }
}
