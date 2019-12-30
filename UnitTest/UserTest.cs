using BeesbyAPI.Models;
using BeesbyAPI.Services;
using BeesbyAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;
using Xunit;

namespace UnitTest
{
    public class UserTest
    {
        private IUserService _userService;

        public UserTest(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public void createWithSuccess()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "JK",
                LastName = "Pedrosa"
            };

            var result = _userService.Create(user);

            Assert.NotNull(result);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.LastName, result.LastName);
        }

        [Fact]
        public void createWithErrorUserFirstName()
        {
            var user = new User
            {
                Id = 2,
                FirstName = "",
                LastName = "Kaick"
            };

            var result = Assert.Throws<Exception>(() => _userService.Create(user));
            Assert.Equal("O primeiro nome deve ser informado", result.Message);
        }
    }
}
