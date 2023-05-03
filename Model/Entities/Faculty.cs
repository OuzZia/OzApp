using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Faculty:BaseEntity
    {

        public string FacultyName { get; set; }
        public virtual List<Department> Departments { get; set; }
    }
}
