using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoMap.Domain.Validation
{
    public class RegistrationFormValidation : Validator
    {
        public RegistrationFormValidation() : base("")
        {
            initializeRegistrationProperties();
        }

        private void initializeRegistrationProperties()
        {
            Properties.Add("username", "");
            Properties.Add("duplicated_password", "");
        }

        public string ValidateUsernameField()
        {
            Errors = "";
            string strRegex = "^[A-Za-z0-9_-]*$";
            if (isStringEmpty(Properties["username"]))
            {
                Errors += "Username field is required. \n";

            }
            else if (!new Regex(strRegex).IsMatch(Properties["username"]))
            {
                Errors += "Username should contain letters and digits only. \n";

            }
            else if (Properties["username"].Length < 5)
            {
                Errors += "Username should include at least 5 characters. \n";
            }
            else if (Properties["username"].Length > 256)
            {
                Errors += "Username must contain up to 256 characters.\n";
            }
            return Errors;
        }

        private void ValidateDuplicatedPassword()
        {
            if (isStringEmpty(Properties["duplicated_password"]))
            {
                Errors += "Duplicate password. \n";
            }


            else if (!string.Equals(Properties["password"], Properties["duplicated_password"]))
            {
                Errors += "Passwords must match. \n";
            }
        }

        public string ValidateRegistrationForm()
        {
            Errors = "";
            ValidateUsernameField();
            ValidateEmailField();
            ValidatePasswordField();
            ValidateDuplicatedPassword();
            return Errors;
        }

    }
}
