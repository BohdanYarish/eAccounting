using System;
using System.Collections.Generic;
using System.Text;

namespace eAccaunting
{
    class ModerationUser : IUser
    {
        private string user_email { get; }
        private string user_password { get; }

        public ModerationUser(string email, string password)
        {
            user_email = email;
            user_password = password;
        }

        public bool IsSuccesfulLogin(string email, string password)
        {
            return user_email == email && user_password == password;
        }
    }
}
