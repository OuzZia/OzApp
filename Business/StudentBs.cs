using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class StudentBs
    {
        private readonly StudentRepository _repo;
        public StudentBs()
        {
            _repo = new StudentRepository();
        }
        public List <Student> GetAll(params string[] includeList)
        {
            return _repo.GetAll(filter:null, includeList);
        }
        public Student GetById(int id)
        {
            return _repo.GetById(id);
        }
        public List<Student> GetAllByDepartmentId(int departmentId, params string [] includeList)
        {
            return _repo.GetAllByDepartmentId(departmentId, includeList);
        }

        public void Insert(Student student)
        {
            _repo.Add(student);
        }
        public Student GetByDepartmentId(int studentid)
        {
            return _repo.GetById(studentid);
        }
        public void Delete(int id)
        {
            _repo.DeleteById(id);
        }
        public void Update(Student student)
        {
            _repo.Update(student);
        }
    }
}
