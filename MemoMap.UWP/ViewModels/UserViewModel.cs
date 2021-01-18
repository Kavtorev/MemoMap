using MemoMap.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using MemoMap.Infrastructure.Validation;
using MemoMap.Domain.Models;

namespace MemoMap.UWP.ViewModels
{
    //public class UserViewModel : INotifyPropertyChanged
    public class UserViewModel : BindableBase

    {
        public UserViewModel()
        {
            User = new User();
            LoginFormValidator = new LoginFormValidation();
            RegistrationFormValidator = new RegistrationFormValidation();
        }
        private User _loggedUser;
        public LoginFormValidation LoginFormValidator { get; set; }
        public RegistrationFormValidation RegistrationFormValidator { get; set; }

        public User LoggedUser
        {
            get => _loggedUser;
            set
            {
                SetField(ref _loggedUser, value);
                OnPropertyChanged(nameof(IsLoggedIn));
                OnPropertyChanged(nameof(notAuthenticated));
            }
        }

        public bool IsLoggedIn
        {
            get => LoggedUser != null;
        }

        public bool notAuthenticated
        {
            get => !IsLoggedIn;
        }

        public User User { get; set; }

        public void LoginFormValidatorSetProperty(string key, string value)
        {
            LoginFormValidator.Properties[key] = value;
            LoginFormValidator.ValidateLoginField();
            RerenderErrorText(nameof(LoginFormValidator));
        }

        public void RegistrationFormValidatorSetProperty(string key, string value)
        {
            RegistrationFormValidator.Properties[key] = value;
            RegistrationFormValidator.ValidateRegistrationForm();
            RerenderErrorText(nameof(RegistrationFormValidator));
        }

        public void RerenderErrorText(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        internal async Task<bool> DoLoginAsync()
        {
            // A user is able to login by an email.

            User userToLogin = await App.UnitOfWork.UserRepository.FindByEmailAsync(User.Email);
            if (userToLogin != null)
            {
                // verify the provided password against the hash
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(User.Password, userToLogin.Password);
                if (isPasswordValid)
                {
                    // authenticating the user 
                    LoggedUser = userToLogin;

                    // show the notification that the user us logged in.
                    return true;
                }
                else
                {
                    //disallow to login and notify that there is something wrong with the provided credentials
                    LoginFormValidator.SetPostValidationErrors("Wrong Credentials");
                }
            }
            else
            {
                // there is no such user
                LoginFormValidator.SetPostValidationErrors("There is no registered user under the provided email.");
            }
            return false;
        }
   
        internal async Task DoRegistrationAsync()
        {
            if (await App.UnitOfWork.UserRepository.FindByEmailAsync(User.Email) == null)
            {
                if (await App.UnitOfWork.UserRepository.FindByUsernameAsync(User.Username) == null)
                {
                    // hashing provided password
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(User.Password);
                    User.Password = passwordHash;
                    // inserting a new entry into the db
                    User user = await App.UnitOfWork.UserRepository.CreateAsync(User);
                    // authenticating the user.
                    LoggedUser = user;

                }
                else
                {
                    // username should be unique
                    RegistrationFormValidator.SetPostValidationErrors("Username is already taken.");
                }
            }
            else
            {
                // there is already a user, registered with the given email
                RegistrationFormValidator.SetPostValidationErrors("The is already registered user under the provided email.");
            }
        }

    }
}
