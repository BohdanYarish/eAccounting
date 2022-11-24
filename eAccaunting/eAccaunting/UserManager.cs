using System;
using System.Collections.Generic;
using System.Text;

namespace eAccaunting
{
    abstract class UserManager
    {
        protected string form_email;
        protected string form_password;

        public abstract IUser CreateUser();
        
    }

    class PersonManager : UserManager
    {
        private PersonalInfo personalInfo;

        public override IUser CreateUser()
        {
            return new PersonUser(personalInfo, form_email, form_password);
        }
    }

    class OrgAgentManager : UserManager
    {
        public override IUser CreateUser()
        {
            return new OrgAgentUser(form_email, form_password);
        }
    }
}
