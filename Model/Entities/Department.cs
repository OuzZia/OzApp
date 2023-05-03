using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Department:BaseEntity
    {
        public string DepartmentName { get; set; }
        public string EducationType { get; set; }
        public int SemesterCount { get; set; }
        public int FacultyID { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Student> Students { get; set; }



    }
}
