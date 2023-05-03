using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }

    }
}
