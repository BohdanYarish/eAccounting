using System;
using System.Collections.Generic;
using System.Text;

namespace eAccaunting
{
    class OrgAgentUser : IUser
    {
        private string user_email { get; }
        private string user_password { get; }

        public OrgAgentUser(string email, string password)
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
