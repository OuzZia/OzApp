using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
    public class StudentAffairDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int FacultyId { get; set; }



    }
}
