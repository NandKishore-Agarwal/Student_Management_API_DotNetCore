using System.Collections.Generic;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Students.Test.Model.ViewModels;
using Students.Test.Services.IServices;

namespace Students.Test.Services.Services
{
    /// <summary>
    /// StudentServiceCachingDecorator class containing methods for Cahching in student service.
    /// </summary>
    public class StudentServiceCachingDecorator : IStudentService
    {
        private readonly IStudentService _studentService;
        private readonly ICacheProvider _cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentServiceCachingDecorator"/> class.
        /// </summary>
        /// <param name="studentService">studentService.</param>
        /// <param name="cacheProvider">cacheProvider.</param>
        public StudentServiceCachingDecorator(IStudentService studentService, ICacheProvider cacheProvider)
        {
            this._studentService = studentService;
            this._cacheProvider = cacheProvider;
        }

        /// <inheritdoc />
        public async Task<Student> GetStudentbyIdAsync(int studentid)
        {
            string cacheName = "Student" + studentid;
            Student student = null;
            bool isExist;
            this._cacheProvider.IsCacheExists<Student>(cacheName, out student, out isExist);
            if (!isExist)
            {
                student = await this._studentService.GetStudentbyIdAsync(studentid).ConfigureAwait(false);
                this._cacheProvider.SetCache(cacheName, student);
            }
            else
            {
                student = this._cacheProvider.GetCache<Student>(cacheName);
            }

            return student;
        }

        /// <inheritdoc />
        public async Task<float> GetAverageGradeAsync(int departmentid)
        {
            string cacheName = "Student" + departmentid;
            float averagescore;
            bool isExist;
            this._cacheProvider.IsCacheExists<float>(cacheName, out averagescore, out isExist);
            if (!isExist)
            {
                averagescore = await this._studentService.GetAverageGradeAsync(departmentid).ConfigureAwait(false);
                this._cacheProvider.SetCache(cacheName, averagescore);
            }
            else
            {
                averagescore = this._cacheProvider.GetCache<float>(cacheName);
            }

            return averagescore;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentStudentViewModel>> GetStudentCountAsync()
        {
            string cacheName = "Student";
            List<DepartmentStudentViewModel> student = new List<DepartmentStudentViewModel>();
            bool isExist;
            this._cacheProvider.IsCacheExists<List<DepartmentStudentViewModel>>(cacheName, out student, out isExist);
            if (!isExist)
            {
                student = await this._studentService.GetStudentCountAsync();
                this._cacheProvider.SetCache(cacheName, student);
            }
            else
            {
                student = this._cacheProvider.GetCache<List<DepartmentStudentViewModel>>(cacheName);
            }

            return student;
        }

        /// <inheritdoc />
        public async Task<List<DropdownViewModel>> GetDepartmentsAsync()
        {
            string cacheName = "Student";
            List<DropdownViewModel> dropdownModel = new List<DropdownViewModel>();
            bool isExist;
            this._cacheProvider.IsCacheExists<List<DropdownViewModel>>(cacheName, out dropdownModel, out isExist);
            if (!isExist)
            {
                dropdownModel = await this._studentService.GetDepartmentsAsync();
                this._cacheProvider.SetCache(cacheName, dropdownModel);
            }
            else
            {
                dropdownModel = this._cacheProvider.GetCache<List<DropdownViewModel>>(cacheName);
            }

            return dropdownModel;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentViewModel>> GetStudentDepartmentsAsync()
        {
            string cacheName = "Student";
            List<DepartmentViewModel> departmentViewModel = new List<DepartmentViewModel>();
            bool isExist;
            this._cacheProvider.IsCacheExists<List<DepartmentViewModel>>(cacheName, out departmentViewModel, out isExist);
            if (!isExist)
            {
                departmentViewModel = await this._studentService.GetStudentDepartmentsAsync().ConfigureAwait(false);
                this._cacheProvider.SetCache(cacheName, departmentViewModel);
            }
            else
            {
                departmentViewModel = this._cacheProvider.GetCache<List<DepartmentViewModel>>(cacheName);
            }

            return departmentViewModel;
        }

        /// <inheritdoc />
        public async Task<List<DepartmentViewModel>> GetStudentbyDepartmentsidAsync(int departmentid)
        {
            string cacheName = "Student" + departmentid;
            List<DepartmentViewModel> departmentViewModel = new List<DepartmentViewModel>();
            bool isExist;
            this._cacheProvider.IsCacheExists<List<DepartmentViewModel>>(cacheName, out departmentViewModel, out isExist);
            if (!isExist)
            {
                departmentViewModel = await this._studentService.GetStudentbyDepartmentsidAsync(departmentid).ConfigureAwait(false);
                this._cacheProvider.SetCache(cacheName, departmentViewModel);
            }
            else
            {
                departmentViewModel = this._cacheProvider.GetCache<List<DepartmentViewModel>>(cacheName);
            }

            return departmentViewModel;
        }

        /// <inheritdoc />
        public async Task<List<Student>> SaveStudents(Student student)
        {
            string cacheName = "Student";
            List<Student> students = new List<Student>();
            bool isExist;
            this._cacheProvider.IsCacheExists<List<Student>>(cacheName, out students, out isExist);
            if (!isExist)
            {
                students = await this._studentService.SaveStudents(student).ConfigureAwait(false);
                this._cacheProvider.SetCache(cacheName, students);
            }
            else
            {
                students = this._cacheProvider.GetCache<List<Student>>(cacheName);
            }

            return students;
        }
    }
}
