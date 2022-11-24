using System;
using System.Collections.Generic;
using System.Text;

namespace eAccaunting
{
    interface IUser
    {
        bool IsSuccesfulLogin(string email, string password);

        
    }
}
