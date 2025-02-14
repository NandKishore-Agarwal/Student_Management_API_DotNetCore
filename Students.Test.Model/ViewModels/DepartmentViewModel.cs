using System.Collections.Generic;
using Hiring.Test.Model;

namespace Students.Test.Model.ViewModels
{
    /// <summary>
    /// DepartmentViewModel.
    /// </summary>
    public class DepartmentViewModel
    {
        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets students.
        /// </summary>
        public List<Student> Students { get; set; }
    }
}
