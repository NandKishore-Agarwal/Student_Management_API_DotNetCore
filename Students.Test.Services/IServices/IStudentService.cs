using System.Collections.Generic;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Students.Test.Model.ViewModels;

namespace Students.Test.Services.IServices
{
    /// <summary>
    /// IStudentService.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Get Student details by Student Id.
        /// </summary>
        /// <param name="studentid">studentid.</param>
        /// <returns>student details.</returns>
        Task<Student> GetStudentbyIdAsync(int studentid);

        /// <summary>
        /// Get average grade by departmet Id.
        /// </summary>
        /// <param name="departmentid">departmentid.</param>
        /// <returns>average grade.</returns>
        Task<float> GetAverageGradeAsync(int departmentid);

        /// <summary>
        /// Get all department and their student count.
        /// </summary>
        /// <returns>.</returns>
        Task<List<DepartmentStudentViewModel>> GetStudentCountAsync();

        /// <summary>
        /// Get all departments, these will be used for data population in dropdown.
        /// </summary>
        /// <returns>.</returns>
        Task<List<DropdownViewModel>> GetDepartmentsAsync();

        /// <summary>
        /// Get all students by department.
        /// </summary>
        /// <returns>.</returns>
        Task<List<DepartmentViewModel>> GetStudentDepartmentsAsync();

        /// <summary>
        /// Get all students by departmentid.
        /// </summary>
        /// <param name="departmentid">departmentid.</param>
        /// <returns>.</returns>
        Task<List<DepartmentViewModel>> GetStudentbyDepartmentsidAsync(int departmentid);

        /// <summary>
        /// Save new student details.
        /// </summary>
        /// <param name="student">student.</param>
        /// <returns>.</returns>
        Task<List<Student>> SaveStudents(Student student);
    }
}
