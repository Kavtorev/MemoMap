using MemoMap.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace MemoMap.UWP.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged

    {
        public UserViewModel()
        {
            User = new User();
        }
        private User _loggedUser;


        public string RepeatedPassword { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public User LoggedUser
        {
            get
            {
                return _loggedUser;
            }

            set
            {
                _loggedUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLoggedIn));
                OnPropertyChanged(nameof(notAuthenticated));
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return LoggedUser != null;
            }
        }

        public bool notAuthenticated
        {
            get
            {
                return !IsLoggedIn;
            }
        }

        public User User { get; set; }


        internal async Task DoLoginAsync()
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

                } else
                {
                    //disallow to login and notify that there is something wrong with the provided credentials
                }
            }
            else
            {
                // there is no such user
            }
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
                    await App.UnitOfWork.UserRepository.CreateAsync(User);
                    // fetching a newly added user
                    User user = await App.UnitOfWork.UserRepository.FindByEmailAsync(User.Email);
                    // authenticating the user.
                    LoggedUser = user;

                } else
                {
                    // username should be unique
                }
            } else
            {
                // there is already a user, registered with the given email
            }
        }

    }
}
