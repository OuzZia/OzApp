using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class StudentAffairBs
    {
        private readonly StudentAffairRepository _repo;
        public StudentAffairBs()
        {
            _repo = new StudentAffairRepository();
        }
        public StudentAffair LogIn(string email, string password,params string[] includeList)
        {
            return _repo.LogIn(email, password, includeList);
        }
        public List<StudentAffair> GetAll()
        {
            return _repo.GetAll();
        }
        public StudentAffair GetByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }
        public void Update(StudentAffair studentAffair)
        {
            _repo.Update(studentAffair);
        }
        public StudentAffair GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Insert(StudentAffair studentAffair)
        {
            _repo.Add(studentAffair);
        }
        public void Delete(int id)
        {
            _repo.DeleteById(id);
        }
    }
}
