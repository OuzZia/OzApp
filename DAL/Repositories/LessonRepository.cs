using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class LessonRepository:RepositoryBase<Lesson, OgrenciSistemiDb>
    {
        public List<Lesson> GetByDepartmentId(int departmentId, params string[] includeList)
        {
            return GetAll(x=> x.DepartmentId==departmentId,includeList);
        }
    }
}
