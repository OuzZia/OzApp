using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class StudentAffairRepository:RepositoryBase<StudentAffair, OgrenciSistemiDb>
    {

        public StudentAffair LogIn(string email, string password,params string[] includeList)
        {
            return Get(x => x.Email == email && x.Password == password, includeList);
        }

        //Bu metot teacher, user ve student için de kullanılacağı için generic type ile repository base içinde yazılmalı.
        public StudentAffair GetByEmail(string email)
        {
            return Get(x => x.Email == email);
        }
    }
}
