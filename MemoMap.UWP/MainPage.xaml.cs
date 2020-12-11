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
using MemoMap.UWP.Views.GroupViews;
using MemoMap.UWP.Views.Map;
using MemoMap.UWP.Views.AccountSettings;
using MemoMap.UWP.ViewModels;
using Windows.UI.ApplicationSettings;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoMap.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel MainViewModel { get; set; }
        public Dictionary<string, System.Type> Routes { get; set; }


        public MainPage()
        {
            this.InitializeComponent();
            this.initializeRoutes();
            MainViewModel = new MainViewModel();
        }

        // to add a new route use 
        private void initializeRoutes()
        {
            // key - value pairs: <title of a page>  - <its data type>.
            Routes = new Dictionary<string, System.Type>
            {
                {"my_maps",  typeof(MyMapsPage)},
                {"create_group",  typeof(CreateGroupPage)},
                {"view_groups",  typeof(ViewGroupPage)},
                {"map",  typeof(MapPage)},
                {"account_settings",  typeof(AccountSettings)}
            };
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem nav_item = args.InvokedItemContainer as NavigationViewItem;
            if (nav_item != null)
            {
                string pageTitle = nav_item.Tag.ToString();
                if (Routes.ContainsKey(pageTitle) 
                        && Routes.TryGetValue(pageTitle, out Type value)){
                    MainFrame.Navigate(value);
                    MainViewModel.setTitle(pageTitle);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ViewGroupPage));
        }

     
        private void ThemeChanger_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.toggleTheme();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Start building "AccountSettingsPane"
            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested += BuildPaneAsync;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //Delete building "AccountSettingsPane"
            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested -= BuildPaneAsync;
        }
        //Authentication form building function
        private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
        {
            var deferral = e.GetDeferral();
            var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", "consumers");
            var command = new WebAccountProviderCommand(msaProvider, GetMsaTokenAsync);
            e.WebAccountProviderCommands.Add(command);
            deferral.Complete();
        }
        //Retrieving account data
        public async void GetMsaTokenAsync(WebAccountProviderCommand command)
        {
            WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
            WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
            if (result.ResponseStatus == WebTokenRequestStatus.Success)
            {
                WebAccount account = result.ResponseData[0].WebAccount;
                StoreWebAccount(account);
            }
        }
        //Saving data in storage
        private void StoreWebAccount(WebAccount account)
        {
            ApplicationData.Current.LocalSettings.Values["CurrentUserProviderId"] = account.WebAccountProvider.Id;
            ApplicationData.Current.LocalSettings.Values["CurrentUserId"] = account.Id;
        }
    }
}
