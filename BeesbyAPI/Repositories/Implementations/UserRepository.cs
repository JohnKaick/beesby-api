using BeesbyAPI.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeesbyAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Create(User user)
        {
            string sql = "INSERT INTO user (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (MySqlConnection db = new MySqlConnection(_configuration.GetConnectionString("MySqlConnectionString")))
            {
                db.Open();
            
                var userResult = db.Execute(sql,
                    new 
                    { 
                        FirstName = user.FirstName, 
                        LastName = user.LastName 
                    });
            
                db.Close();
            
            }

            return user;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM user WHERE Id = @Id";

            using (MySqlConnection db = new MySqlConnection(_configuration.GetConnectionString("MySqlConnectionString")))
            {
                db.Open();

                var userResult = db.Execute(sql,
                    new
                    {
                        Id = id
                    });

                db.Close();

                return true;
            }
        }

        public List<User> FindAll()
        {
            string sql = "SELECT * FROM user";

            using (MySqlConnection db = new MySqlConnection(_configuration.GetConnectionString("MySqlConnectionString")))
            {
                db.Open();

                var userResult = db.Query<User>(sql).ToList();

                db.Close();

                return userResult;
            }
        }

        public User FindById(int id)
        {
            string sql = "SELECT * FROM user WHERE Id = @Id";

            using (MySqlConnection db = new MySqlConnection(_configuration.GetConnectionString("MySqlConnectionString")))
            {
                db.Open();

                var userResult = db.Query<User>(sql,
                    new
                    {
                        Id = id
                    })
                    .SingleOrDefault();

                db.Close();

                return userResult;
            }
        }

        public User Update(int id, User user)
        {
            string sql = "UPDATE user SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";

            using (MySqlConnection db = new MySqlConnection(_configuration.GetConnectionString("MySqlConnectionString")))
            {
                db.Open();

                var userResult = db.Execute(sql,
                    new
                    {
                        Id = id,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    });

                db.Close();

                return user;
            }
        }

    }
}
