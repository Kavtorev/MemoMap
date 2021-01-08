using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Validation
{
    public class LoginFormValidation: Validator
    {
        public LoginFormValidation():base("")
        {

        }

   

        public string ValidateLoginField()
        {
            Errors = "";
            ValidateEmailField();
            ValidatePasswordField();
            return Errors;
        }
    }
}
