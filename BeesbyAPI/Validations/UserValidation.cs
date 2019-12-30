using BeesbyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesbyAPI.Validations
{
    public class UserValidation
    {
        public void Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new Exception("O primeiro nome deve ser informado");
            }
        }

        public void Update(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new Exception("O primeiro nome deve ser informado");
            }
        }
    }
}
