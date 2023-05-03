using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class LessonBs
    {
        private readonly LessonRepository _repo;
        public LessonBs()
        {
            _repo = new LessonRepository();
        }
        public List<Lesson> GetAll()
        {
            return _repo.GetAll(filter:null);
        }
        public List<Lesson> GetByDepartmentId(int departmentId, params string[] includeList)
        {
            return _repo.GetByDepartmentId(departmentId, includeList);
        }
        public void Insert(Lesson lesson)
        {
            _repo.Add(lesson);
        }
    }
}
