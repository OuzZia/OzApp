using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class StudentAffair:BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FacultyId { get; set; }
        public Department Department { get; set; }
        public int RoleId { get; set; }
        public Faculty Faculty { get; set; }
        public Role Role { get; set; }




    }
}
