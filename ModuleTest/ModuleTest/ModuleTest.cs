using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace eAccaunting
{
    class ModuleTest
    {
        PersonUser new_user;
        List<PersonUser> person_list;
        string test_password = "12345678";
        string test_email = "test@example.com";
        OrgAgentManager org_manager;
    
       [SetUp]
        public void Setup()
        {
            new_user = new PersonUser(new PersonalInfo(name: "Ivan", 
                                                             sur_name: "Havriliv",
                                                             middle_name: "Yosypovich",
                                                             birth_date: new DateTime(2000, 1, 1),
                                                             user_status: new List<UserStatus>() {UserStatus.INTERNALLY_DISPLACED,
                                                                                                  UserStatus.IN_WAR_HOMELESS },
                                                             docs_list: new List<string>() {"localhost:3000/api/docs/passport0.img"}), 
                                            "have_fun@gmail.com", 
                                            "12345678");

            person_list = new List<PersonUser>() {new PersonUser(new PersonalInfo(name: "Ivan",
                                                             sur_name: "Havriliv",
                                                             middle_name: "Yosypovich",
                                                             birth_date: new DateTime(2000, 1, 1),
                                                             user_status: new List<UserStatus>() {UserStatus.INTERNALLY_DISPLACED,
                                                                                                  UserStatus.IN_WAR_HOMELESS },
                                                             docs_list: new List<string>() {"localhost:3000/api/docs/passport10.img"}),
                                                             "have_fun@gmail.com",
                                                             "12345678"),
                                                          new PersonUser(new PersonalInfo(name: "Tom",
                                                             sur_name: "Jarry",
                                                             middle_name: "",
                                                             birth_date: new DateTime(2000, 1, 1),
                                                             user_status: new List<UserStatus>(),
                                                             docs_list: new List<string>()),
                                                             "have_fun1@gmail.com",
                                                             "12345678"),
                                                          new PersonUser(new PersonalInfo(name: "Morty",
                                                             sur_name: "Smith",
                                                             middle_name: "",
                                                             birth_date: new DateTime(2000, 1, 1),
                                                             user_status: new List<UserStatus>(),
                                                             docs_list: new List<string>()),
                                                             "have_fun2@gmail.com",
                                                             "12345678")};
        }

        [Test]
        public void LoginTest()
        {
            var selected_user = (from user in person_list
                                where string.Equals(user.GetEmail(), new_user.GetEmail())
                                select user).ToList();
            Assert.AreEqual(selected_user.Count, 1);
            Assert.IsTrue(string.Equals(selected_user.ElementAt(0).GetPersonalInfo().sur_name, new_user.GetPersonalInfo().sur_name));
        }

        [Test]
        public void FilterByStatusTest()
        {
            List<PersonUser> selected_user;

            org_manager.SetPersons(person_list);
            selected_user = org_manager.FilterPersonsByStatus(new List<UserStatus>() {UserStatus.DISABLED_VETERANS, UserStatus.IN_WAR_HOMELESS });


            Assert.AreEqual(selected_user.Count, 1);
            //Assert.AreEqual(selected_user.ElementAt(1).GetPersonalInfo().sur_name, "Tom");
        }

        [Test]
        public void IsCorrectSaved()
        {
            List<PersonUser> selected_user;

            org_manager.SetPersons(person_list);


            Assert.AreEqual(org_manager.SaveUsers().Count, 3);
            //Assert.AreEqual(selected_user.ElementAt(1).GetPersonalInfo().sur_name, "Tom");
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {

            var variable = new Rights();

            var result = variable.CanBeCancelledBy(new ModerationUser { IsAdmin = true });

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation()
        {
            var user = new ModerationUser();
            var variable = new Rights { MadeBy = user };

            var result = variable.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            var variable = new Rights { MadeBy = new ModerationUser() };

            var result = variable.CanBeCancelledBy(new ModerationUser());

            Assert.IsFalse(result);
        }

        [Test]
        public void IsPasswordCorrect_ReturnsTrue()
        {
            var user = new ModerationUser(log: "andrii@gmail.com", pass: "andrii2002");
            // var user = new User(log: "andrii@gmail.com", pass: "andrii&$2002");

            var result = user.isPasswordCorrect();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidEmail_ReturnsTrue()
        {
            var user = new ModerationUser("andrii@gmail.com", "andrii2002");
         

            var result = user.isValidEmail(user.user_email);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsTaxpayercardValid()
        {
            var user = new ModerationUser(log: "andrii@gmail.com", pass: "andrii2002", taxpayerccard: "1234567890");


            var result = user.isTaxpayercardValid(user.TaxpayerCard);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsLoginTest()
        {
            var user = new ModerationUser(log: "andrii@gmail.com", pass: "andrii2002", taxpayerccard: "1234567890");

            var result = user.isLogin(user.user_email, user.user_password, user.TaxpayerCard);

            Assert.IsTrue(result);
        }
    }
}
