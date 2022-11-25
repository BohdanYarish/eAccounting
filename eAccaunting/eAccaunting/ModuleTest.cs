﻿using System;
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
                                where user.GetEmail() == new_user.GetEmail()
                                select user).ToList<PersonUser>();
            Assert.AreEqual(selected_user, new List<PersonUser>() {new_user});
        }
    }
}
