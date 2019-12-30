using BeesbyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesbyAPI.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User FindById(int id);
        List<User> FindAll();
        User Update(int id, User user);
        bool Delete(int id);
    }
}