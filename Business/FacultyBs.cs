using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class FacultyBs
    {
        private readonly FacultyRepository _repo;
        public FacultyBs()
        {
            _repo = new FacultyRepository();
        }
        public List <Faculty> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
