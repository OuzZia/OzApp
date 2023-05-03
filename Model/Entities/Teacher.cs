using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Teacher:BaseEntity
    {
        public string TeacherName { get; set; }
        public int DepartmentId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfRegistiration { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string IDNumber { get; set; }
        public Role Role { get; set; }
        public virtual List<TeacherRole> TeacherRoles { get; set; }
        public Department Department { get; set; }
        public Lesson Lesson { get; set; }
        public List<TeacherLesson> TeacherLessons { get; set; }












    }
}
