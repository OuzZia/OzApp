using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class TeacherRoleBs
    {
        private readonly TeacherRoleRepository _repo;
        public TeacherRoleBs()
        {
            _repo = new TeacherRoleRepository();
        }
        public List<TeacherRole> GetAll(params string[] includeList)
        {
            return _repo.GetAll(filter:null, includeList);
        }
        public void Insert(TeacherRole teacherRole)
        {
            _repo.Add(teacherRole);
        }
        public TeacherRole GetByTeacherId(int teacherId)
        {
           return _repo.GetByTeacherId(teacherId);
        }
        public void Delete(TeacherRole teacherRole)
        {
            _repo.Delete(teacherRole);
        }
        public void Update(TeacherRole teacherRole)
        {
            _repo.Update(teacherRole);
        }
    }
}
