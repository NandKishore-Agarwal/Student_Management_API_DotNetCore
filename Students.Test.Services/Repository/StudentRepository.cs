using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiring.Test.Model;
using Students.Test.Model.IRepository;

namespace Students.Test.Model.Repository
{
    /// <summary>
    /// StudentRepository.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>
            {
                new Student { Id = 1, FirstName = "John", LastName = "Doe", Score = 78.5f, Department = new Department { Id = 1, Name = "Mechanical", Location = "Mumbai" } },
                new Student { Id = 2, FirstName = "Dean", LastName = "Smith", Score = 89.2f, Department = new Department { Id = 2, Name = "Computer", Location = "Mumbai" } },
                new Student { Id = 3, FirstName = "Jeff", LastName = "Stricklin", Score = 98.4f, Department = new Department { Id = 1, Name = "Mechanical", Location = "Mumbai" } },
                new Student { Id = 4, FirstName = "Brad", LastName = "Johnson", Score = 97.5f, Department = new Department { Id = 2, Name = "Computer", Location = "Mumbai" } },
                new Student { Id = 5, FirstName = "Manoj", LastName = "Tiwari", Score = 95.4f, Department = new Department { Id = 1, Name = "Mechanical", Location = "Mumbai" } },
                new Student { Id = 6, FirstName = "Doug", LastName = "Johns", Score = 94.7f, Department = new Department { Id = 2, Name = "Computer", Location = "Mumbai" } },
                new Student { Id = 7, FirstName = "Scott", LastName = "Clark", Score = 90.3f, Department = new Department { Id = 1, Name = "Mechanical", Location = "Mumbai" } },
                new Student { Id = 9, FirstName = "Michael", LastName = "Clark", Score = 99.0f, Department = new Department { Id = 2, Name = "Computer", Location = "Mumbai" } },
                new Student { Id = 10, FirstName = "Johnson", LastName = "Doe", Score = 82.4f, Department = new Department { Id = 3, Name = "Mechanical", Location = "Pune" } },
                new Student { Id = 11, FirstName = "John", LastName = "Doe", Score = 78.5f, Department = new Department { Id = 4, Name = "Computer", Location = "Pune" } },
                new Student { Id = 12, FirstName = "Dean", LastName = "Smith", Score = 89.2f, Department = new Department { Id = 3, Name = "Mechanical", Location = "Pune" } },
                new Student { Id = 13, FirstName = "Jeff", LastName = "Stricklin", Score = 98.4f, Department = new Department { Id = 4, Name = "Computer", Location = "Pune" } },
                new Student { Id = 14, FirstName = "Brad", LastName = "Johnson", Score = 97.5f, Department = new Department { Id = 3, Name = "Mechanical", Location = "Pune" } },
                new Student { Id = 15, FirstName = "Manoj", LastName = "Tiwari", Score = 95.4f, Department = new Department { Id = 4, Name = "Computer", Location = "Pune" } },
                new Student { Id = 16, FirstName = "Doug", LastName = "Johns", Score = 94.7f, Department = new Department { Id = 3, Name = "Mechanical", Location = "Pune" } },
                new Student { Id = 17, FirstName = "Scott", LastName = "Clark", Score = 90.3f, Department = new Department { Id = 4, Name = "Computer", Location = "Pune" } },
                new Student { Id = 8, FirstName = "Michael", LastName = "Clark", Score = 99.0f, Department = new Department { Id = 3, Name = "Mechanical", Location = "Pune" } },
                new Student { Id = 18, FirstName = "Johnson", LastName = "Doe", Score = 82.4f, Department = new Department { Id = 4, Name = "Computer", Location = "Pune" } },
            };

        /// <inheritdoc />
        public async Task<Student> GetStudentAsync(int studentid)
        {
            return await Task.Run(() => this.students.FirstOrDefault(x => x.Id == studentid)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<Student>> GetDepartmentAsync(int departmentid)
        {
            List<Student> student = null;
            student = await Task.Run(() => this.students.Where(x => x.Department.Id == departmentid).ToList()).ConfigureAwait(false);
            return student;
        }

        /// <inheritdoc />
        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await Task.Run(() => this.students.ToList()).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public List<Student> GetAllStudent()
        {
            return this.students.ToList();
        }

        /// <inheritdoc />
        public async Task<List<Student>> SaveStudentAsync(Student student)
        {
            this.students.Add(student);
            return await this.GetAllStudentAsync().ConfigureAwait(false);
        }
    }
}
