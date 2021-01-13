using MemoMap.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoMap.UWP.Views.UserViews
{
    public sealed partial class RegisterDialog : ContentDialog
    {
        public UserViewModel UserViewModel { get; set; }
        public RegisterDialog()
        {
            this.InitializeComponent();
            UserViewModel = App.UserViewModel;

        }

        private async void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            // args.Cancel -> true - leave opened dialog
            // args.Cancel -> false - close dialog 
            if (args.Result == ContentDialogResult.Primary)
            {
                args.Cancel = true;

                // if there are validation errors
                if (!string.IsNullOrEmpty(UserViewModel.RegistrationFormValidator.ValidateRegistrationForm()))
                {
                    UserViewModel.RerenderErrorText(nameof(UserViewModel.RegistrationFormValidator));
                }
                else
                {
                    // if there are no validation errors then...
                    // try to login
                    await UserViewModel.DoRegistrationAsync();
                    // if there post-validation errors
                    if (!string.IsNullOrEmpty(UserViewModel.RegistrationFormValidator.Errors))
                    {
                        // show post-validation errors
                        UserViewModel.RerenderErrorText(nameof(UserViewModel.RegistrationFormValidator));
                    }
                    else
                    {
                        // if data passed all the validations close the dialog
                        Hide();
                    }
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void UsernameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserViewModel.RegistrationFormValidatorSetProperty("username", UsernameField.Text);
        }

        private void EmailField_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserViewModel.RegistrationFormValidatorSetProperty("email", EmailField.Text);
        }

        private void PasswordField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UserViewModel.RegistrationFormValidatorSetProperty("password", PasswordField.Password);
        }

        private void RepeatedPasswordField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UserViewModel.RegistrationFormValidatorSetProperty("duplicated_password", RepeatedPasswordField.Password);
        }


    }
}
