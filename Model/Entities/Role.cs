using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Role:BaseEntity
    {
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
    }
}
