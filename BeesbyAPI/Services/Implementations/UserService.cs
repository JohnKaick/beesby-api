using BeesbyAPI.Models;
using BeesbyAPI.Repositories;
using BeesbyAPI.Services;
using BeesbyAPI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeesbyAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            var validation = new UserValidation();
            validation.Create(user);
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        public User FindById(int id)
        {
            return _repository.FindById(id);
        }

        public User Update(int id, User user)
        {
            var validation = new UserValidation();
            validation.Update(user);
            return _repository.Update(id, user);
        }
    }
}
