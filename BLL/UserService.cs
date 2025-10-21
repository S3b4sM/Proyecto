using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class UserService
    {
        UserRepository UserRepository = new UserRepository();
        public Usuario ValidateUser(string username, string password)
        {
            return UserRepository.Validate(username, password);
        }
        public Usuario RegisterUser(string username, string password, string firstName, string lastName)
        {
            string cleanUser = username.Trim().ToLower();
            if (UserRepository.UserExists(cleanUser))
            {
                return null;
            }
            return UserRepository.Register(cleanUser, password, firstName.Trim(), lastName.Trim());
        }
    }
}
