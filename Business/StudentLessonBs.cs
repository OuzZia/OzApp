using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class StudentLessonBs
    {
        private readonly StudentLessonRepository _repo;
        public StudentLessonBs()
        {
            _repo = new StudentLessonRepository();
        }
        public void Delete(StudentLesson student)
        {
            _repo.Delete(student);
        }
       public List<StudentLesson> GetAllStudentLessonsById(int studentId)
        {
            return _repo.GetAllByStudentId(studentId);
        }
   
    } 
}
