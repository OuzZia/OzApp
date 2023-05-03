using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Models
{
    public class RoleDepartmentVm
    {
        public List<Department> Departments  { get; set; }
        public List<Role> Roles { get; set; }

    }
}
