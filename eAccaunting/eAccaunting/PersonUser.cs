using System;
using System.Collections.Generic;
using System.Text;

namespace eAccaunting
{
    enum UserStatus
    {
        LOW_INCOME_FAMILIES,
        IN_WAR_INJURED_CHILDREN,
        MANY_CHILDRENS_FAMILIES,
        IN_WAR_DISABLED,
        DISABLED_VETERANS,
        INTERNALLY_DISPLACED,
        IN_WAR_HOMELESS
    }

    enum UserType
    {
        PERSON,
        ORGANIZATION_AGENT,
        MODERATION_COWORKER
    }

    struct PersonalInfo
    {
        private string name { get; }
        private string sur_name { get; }
        private string middle_name { get; }
        private DateTime birth_date { get; }
        private List<UserStatus> user_status { get; }
        private List<string> docs_list { get; }

        public PersonalInfo(string name, 
                            string sur_name, 
                            string middle_name, 
                            DateTime birth_date, 
                            List<UserStatus> user_status, 
                            List<string> docs_list)
        {
            this.name = name;
            this.sur_name = sur_name;
            this.middle_name = middle_name;
            this.birth_date = birth_date;
            this.user_status = user_status;
            this.docs_list = docs_list;
        }
    }

    class PersonUser : IUser
    {
        private PersonalInfo personal_info;

        private string user_email { get; }
        private string user_password { get; }

        public PersonUser(PersonalInfo personal_info, string email, string password)
        {
            this.personal_info = personal_info;
            user_email = email;
            user_password = password;
        }

        public bool IsSuccesfulLogin(string email, string password)
        {
            return user_email == email && user_password == password;
        }
    }
}
