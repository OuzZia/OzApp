using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class StudentRepository:RepositoryBase<Student,OgrenciSistemiDb>
    {
        public Student GetByDepartmentId(int id)
        {
            return GetById(id);
        }
        public List<Student> GetAllByDepartmentId(int departmentId, params string[] includeList)
        {
            return GetAll(x => x.DepartmentId == departmentId, includeList);
        }
    }
}
