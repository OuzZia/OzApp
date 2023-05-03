using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class DepartmentBs
    {
        private readonly DepartmentRepository _repo;
        public DepartmentBs()
        {
            _repo = new DepartmentRepository();
        }
        public List<Department> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
