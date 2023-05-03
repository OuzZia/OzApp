using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class TeacherRole:BaseEntity
    {
        public int TeacherId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
