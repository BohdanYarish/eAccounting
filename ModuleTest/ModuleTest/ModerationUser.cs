using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace eAccaunting
{
    public class eSupport
    {
       
    }

    public class Rights
    {
        public ModerationUser MadeBy { get; set; }

        public bool CanBeCancelledBy(ModerationUser user)
        {
            return (MadeBy == user);
        }

    }
       
    public class ModerationUser : IUser
    {
        public string user_email { get; set; }
        public string user_password { get; set; }
        public string TaxpayerCard { get; set; }
        public bool IsAdmin { get; set; }

        public string birthdate { get; set; }

        public ModerationUser() { }
        public ModerationUser(string log, string pass)
        {
            user_email = log;
            user_password = pass;
        }
        public ModerationUser(string log, string pass, string taxpayerccard)
        {
            user_email = log;
            user_password = pass;
            TaxpayerCard = taxpayerccard;
        }

        public bool isLogin(string log, string pass, string taxpayerccard)
        {
            if (user_email == null || user_password == null || TaxpayerCard == null)
            {
                return false;
            }


            return true;
        }

        public bool CheckDateFormat(DateTime dat)
        {
            return true;

        }
        public bool isPasswordEntered()
        {
            string varpass;

            varpass = user_password;

            if (user_password == null)
            {
                return false;
            }

            return true;
        }
        public bool isPasswordCorrect()
        {
            string varpass;

            varpass = user_password;



            string specialChar = "/@'!£$&?";

            foreach (var item in specialChar)
            {
                if (user_password.Contains(item))
                {
                    return false;
                }
            }


            return true;
        }

        public bool isValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isTaxpayercardValid(string taxpayercard)
        {
            if (taxpayercard == null)
            {
                return false;
            }

            //if ( Regex.IsMatch(taxpayercard, @"$%/d") is false)
            //{
            //    return false;
            //}

            if (taxpayercard.Length != 10)
            {
                return false;
            }

            return true;

        }

        public bool IsSuccesfulLogin(string email, string password)
        {
            return user_email == email && user_password == password;
        }
    }
}
