using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeacherLessonRepository : RepositoryBase<TeacherLesson, OgrenciSistemiDb>
    {
        public List<TeacherLesson> GetByDepartmentId(int departmentId, params string[] includeList)
        {
            return GetAll(x => x.Lesson.DepartmentId == departmentId, includeList);
        }
        public List<TeacherLesson> GetAllByTeacherId(int teacherId)
        {
            return GetAll(x => x.TeacherId == teacherId);
        }
    }
}
