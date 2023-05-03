using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class TeacherLessonBs
    {
        private readonly TeacherLessonRepository _repo;
        public TeacherLessonBs()
        {
            _repo = new TeacherLessonRepository();
        }
        public List<TeacherLesson> GetByDepartmentId(int departmentId,params string[] includeList)
        {
            return _repo.GetByDepartmentId(departmentId, includeList);
        }
        public void Insert(TeacherLesson teacherLesson)
        {
           _repo.Add(teacherLesson);
        }
        public List<TeacherLesson> GetAllByTeacherId(int teacherId)
        {
            return _repo.GetAllByTeacherId(teacherId);
        }
        public void Delete(TeacherLesson teacherLesson)
        {
            _repo.Delete(teacherLesson);
        }
        public void Update(TeacherLesson teacherLesson)
        {
            _repo.Update(teacherLesson);
        }
    }
}
