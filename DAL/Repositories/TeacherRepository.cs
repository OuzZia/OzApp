using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class TeacherRepository:RepositoryBase<Teacher,OgrenciSistemiDb>
    {
        

        //public Teacher GetById(int id, params string[] includeList)
        //{
        //    return Get(x => x.TeacherID==id, includeList);
        //}
        
        public Teacher LogIn(string email, string password, params string[] includeList)
        {
            return Get(x => x.Email == email && x.Password == password, includeList);
        }
        public List<Teacher> GetByDepartmentId(int departmentId, params string[] includeList)
        {
            return GetAll(x => x.DepartmentId == departmentId, includeList);
        }
    }
}
