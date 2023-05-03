using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business
{
    public class TeacherBs
    {
        private readonly TeacherRepository _repo;
        public TeacherBs()
        {
            _repo = new TeacherRepository();
        }
        public Teacher LogIn(string email, string password, params string [] includeList)
        {
            return _repo.LogIn(email, password, includeList);
        }
        public List<Teacher> GetAll(params string[] includeList)
        {
            return _repo.GetAll(filter:null, includeList);
        }
        public List<Teacher> GetByDepartmentId(int departmentId, params string[] includeList)
        {
            return _repo.GetByDepartmentId(departmentId, includeList);
        }
         public void Insert(Teacher teacher)
        {
         _repo.Add(teacher);
        }
        public void Delete(int id)
        {
           _repo.DeleteById(id);
        }
        public Teacher GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Update(Teacher teacher)
        {
            _repo.Update(teacher);
        }
    }
}
