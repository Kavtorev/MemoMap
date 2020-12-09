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
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoMap.UWP.Views.AccountSettings
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AccountSettings : Page
    {
        public AccountSettings()
        {
            this.InitializeComponent();
        }

        private async void button1clickAsync(object sender, RoutedEventArgs e)
        {
            string providerId = ApplicationData.Current.LocalSettings.Values["CurrentUserProviderId"]?.ToString();
            string accountId = ApplicationData.Current.LocalSettings.Values["CurrentUserId"]?.ToString();
            if ((providerId != null) & (accountId != null))
            {
                WebAccountProvider provider = await WebAuthenticationCoreManager.FindAccountProviderAsync(providerId);
                WebAccount account = await WebAuthenticationCoreManager.FindAccountAsync(provider, accountId);
                WebTokenRequest request = new WebTokenRequest(provider, "wl.basic");
                WebTokenRequestResult result = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(request, account);
                ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserProviderId");
                ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserId");
                await account.SignOutAsync();
                var messageDialog = new MessageDialog("Logged out.");
                await messageDialog.ShowAsync();
            }
        }
    }
}
