using System;
using System.Collections.Generic;
using System.Text;

namespace Hiring.Test.Model
{
    /// <summary>
    /// Student Class.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Department.
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or Sets Score.
        /// </summary>
        public float Score { get; set; }
    }
}
