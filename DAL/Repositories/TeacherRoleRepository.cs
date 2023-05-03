using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeacherRoleRepository:RepositoryBase<TeacherRole, OgrenciSistemiDb>
    {
        public TeacherRole GetByTeacherId(int teacherId)
        {
            return Get(x => x.TeacherId == teacherId);
        }
    }
}
