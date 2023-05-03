using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class UserBs
    {
        private readonly UserRepository _repo;
        public UserBs()
        {
            _repo = new UserRepository();
        }
        public List<User> GetAll()
        {
            return _repo.GetAll();
        }
        public User GetByEmail(string email)
        {
           return _repo.GetByEmail(email);
        }
        public void Delete(User user)
        {
            _repo.Delete(user);
        }
        public void Insert(User user)
        {
            _repo.Add(user);
        }
        public void Update(User user)
        {
            _repo.Update(user);
        }
    }
}
