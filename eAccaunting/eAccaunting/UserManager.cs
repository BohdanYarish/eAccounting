﻿using System;
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
        private List<PersonUser> persons_to_choose;

        public override IUser CreateUser()
        {
            return new OrgAgentUser(form_email, form_password);
        }

        public void LoadUsers(Dictionary<string, PersonUser> db_immitation)
        {
            if (db_immitation.Count == 0)
                return;

            foreach(var item in db_immitation)
            {
                persons_to_choose.Add(item.Value);
            }

            return;
        }

        public List<PersonUser> FilterPersonsByStatus(List<UserStatus> chosen_statuses)
        {
            List<PersonUser> persons_with_statuses = new List<PersonUser>();

            foreach(var person in persons_to_choose)
            {
                if (CheckPersonStatuses(person, chosen_statuses))
                    persons_with_statuses.Add(person);
            }

            return persons_with_statuses;
        }

        private bool CheckPersonStatuses(PersonUser person, List<UserStatus> status_list)
        {
            foreach (var item in person.GetPersonalInfo().user_status)
                if (status_list.Contains(item))
                    return true;
            return false;
        }
    }
}
