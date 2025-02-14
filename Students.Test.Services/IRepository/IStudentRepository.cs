using System.Collections.Generic;
using System.Threading.Tasks;
using Hiring.Test.Model;

namespace Students.Test.Model.IRepository
{
    /// <summary>
    /// IStudentRepository.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Get Student by studentid.
        /// </summary>
        /// <param name="studentid">studentid.</param>
        /// <returns>.</returns>
        Task<Student> GetStudentAsync(int studentid);

        /// <summary>
        /// Get student & Department details by departmentid.
        /// </summary>
        /// <param name="departmentid">departmentid.</param>
        /// <returns>.</returns>
        Task<List<Student>> GetDepartmentAsync(int departmentid);

        /// <summary>
        /// Get All student Async.
        /// </summary>
        /// <returns>.</returns>
        Task<List<Student>> GetAllStudentAsync();

        /// <summary>
        /// Get All student.
        /// </summary>
        /// <returns>.</returns>
        List<Student> GetAllStudent();

        /// <summary>
        /// Save student details.
        /// </summary>
        /// <param name="student">.</param>
        /// <returns>.</returns>
        Task<List<Student>> SaveStudentAsync(Student student);
    }
}
