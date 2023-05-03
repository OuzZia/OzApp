using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Models
{
    public class NewTeacherVm
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfRegistiration { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public int[] LessonIds { get; set; }
    }
}
