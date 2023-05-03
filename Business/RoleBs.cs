using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class RoleBs
    {
        private readonly RoleRepository _repo;
        public RoleBs()
        {
            _repo = new RoleRepository();
        }
        public List<Role> GetAll()
        {
            return _repo.GetAll();
        }
        public Role GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
