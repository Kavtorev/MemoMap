using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoMap.Infrastructure.Validation
{
    public class Validator
    {
        public string Errors { get; set; }
        public Dictionary<string, string> Properties;

        public Validator(string errVal)
        {
            Errors = errVal;
            Properties = new Dictionary<string, string>();
            InitializeProperties();
        }

        protected bool isStringEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        private void InitializeProperties()
        {
            Properties.Add("email", "");
            Properties.Add("password", "");
        }

        public void SetPostValidationErrors(string errorstring)
        {
            Errors = errorstring;
        }

        protected void ValidateEmailField()
        {
            string emailRegex = "^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$";
            if (isStringEmpty(Properties["email"]))
            {
                Errors += "Email Field is required.\n";
            }
            else if (Properties["email"].Length > 256)
            {
                Errors += "Email must contain up to 256 characters.\n";
            }
            else if (!new Regex(emailRegex).IsMatch(Properties["email"]))
            {
                Errors += "Invalid email format. \n";
            }
        }

        protected void ValidatePasswordField()
        {
            string passRegex = "^(?=.*[A-Z].*[A-Z])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,15}$";
            if (isStringEmpty(Properties["password"]))
            {
                Errors += "Password Field is required. \n";
            }
            else if (!new Regex(passRegex).IsMatch(Properties["password"]))
            {
                Errors = "Password must contain at least 8 characters (up to 15),\nlower and upper case letters, \ndigits. \n";
            }
        }


    }
}
