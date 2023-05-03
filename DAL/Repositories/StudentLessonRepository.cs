using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class StudentLessonRepository:RepositoryBase<StudentLesson,OgrenciSistemiDb>
    {
        public List<StudentLesson> GetAllByStudentId(int studentId)
        {
            return GetAll(x => x.StudentId == studentId);
        }
    }
}
