using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Models
{
    public class UpdateStudentVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfRegistiration { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public int StudentSemesterCount { get; set; }

    }
}
