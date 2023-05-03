using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Models
{
    public class TeacherIndexVm
    {
        public List<Teacher> TeacherList { get; set; }
        public List<Role> RoleList { get; set; }
        public List<Lesson> LessonList { get; set; }
        public List<TeacherRole> TeacherRoleList { get; set; }

    }
}
