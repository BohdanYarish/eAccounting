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
        private List<PersonUser> persons_to_choose;

        public void SetPersons(List<PersonUser> persons)
        {
            if (persons == null)
                return;
        
            persons_to_choose = persons;
        }

        public override IUser CreateUser()
        {
            return new OrgAgentUser(form_email, form_password);
        }

        public void LoadUsers(Dictionary<string, PersonUser> db_immitation)
        {
            if (db_immitation.Count == 0)
                return;
            persons_to_choose = new List<PersonUser>();

            foreach (var item in db_immitation)
            {
                persons_to_choose.Add(item.Value);
            }

            return;
        }

        public List<PersonUser> FilterPersonsByStatus(List<UserStatus> chosen_statuses)
        {
            List<PersonUser> persons_with_statuses = new List<PersonUser>();

            if (persons_to_choose == null || chosen_statuses == null)
                return persons_with_statuses;

            foreach(var person in persons_to_choose)
            {
                if (CheckPersonStatuses(person, chosen_statuses))
                    persons_with_statuses.Add(person);
            }

            return persons_with_statuses;
        }

        public Dictionary<string, PersonUser> SaveUsers()
        {
            Dictionary<string, PersonUser> db = new Dictionary<string, PersonUser>();

            foreach(var item in persons_to_choose)
            {
                if (!db.ContainsKey(item.GetEmail()))
                    db.Add(item.GetEmail(), item);
            }

            return db;
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
