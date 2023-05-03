using DAL.Context;
using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository:RepositoryBase<User,OgrenciSistemiDb>
    {
        public User GetByEmail(string email)
        {
            return Get(x => x.Email == email);
        }
    }
}
