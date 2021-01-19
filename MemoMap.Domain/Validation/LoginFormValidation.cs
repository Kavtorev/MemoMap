using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Validation
{
    public class LoginFormValidation : Validator
    {
        public LoginFormValidation() : base("")
        {

        }



        public string ValidateLoginField()
        {
            Errors = "";
            //ValidateEmailField();
            //ValidatePasswordField();
            return Errors;
        }
    }
}
