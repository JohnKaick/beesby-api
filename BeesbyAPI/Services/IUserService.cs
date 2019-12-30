using BeesbyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesbyAPI.Services
{
    public interface IUserService
    {
        User Create(User user);
        User FindById(int id);
        List<User> FindAll();
        User Update(int id, User user);
        void Delete(int id);
    }
}