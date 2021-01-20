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
using MemoMap.UWP.Views.Location;
using MemoMap.UWP.Views.AccountSettings;
using MemoMap.UWP.ViewModels;
using Windows.UI.ApplicationSettings;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using MemoMap.UWP.Views.UserViews;
using MemoMap.UWP.Views.MapViews;
using MapPage = MemoMap.UWP.Views.Location.MapPage;
using MemoMap.UWP.Views.InvitationViews;
using MemoMap.Domain;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoMap.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel MainViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public MapViewModel MapViewModel { get; set; }
        public Dictionary<string, Type> Routes { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeRoutes();
            MainViewModel = new MainViewModel();
            UserViewModel = App.UserViewModel;
        }

        // include new routes for pages here
        private void InitializeRoutes()
        {
            // key - value pairs: <title of a page>  - <its data type>.
            Routes = new Dictionary<string, Type>
            {
                {"my_maps",  typeof(ViewMapsPage)},
                //{"create_map", typeof(Views.GroupViews.CreateMapPage)},
                {"Originate a new group",  typeof(CreateGroupPage)},
                {"Your group list",  typeof(ViewGroupPage)},
                {"map_page",  typeof(MapPage)},
                {"account_settings",  typeof(AccountSettings)},
                {"Invitations", typeof(InvitationsPage)}
            };
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem nav_item = args.InvokedItemContainer as NavigationViewItem;
            if (nav_item != null)
            {
                string pageTitle = nav_item.Tag.ToString();
                if (Routes.ContainsKey(pageTitle)
                        && Routes.TryGetValue(pageTitle, out Type value))
                {
                    MainFrame.Navigate(value);
                    MainViewModel.setTitle(pageTitle);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(MapPage));
        }


        private void ThemeChanger_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.toggleTheme();
        }
        //protected override void onnavigatedto(navigationeventargs e)
        //{
        //    //start building "accountsettingspane"
        //    accountssettingspane.getforcurrentview().accountcommandsrequested += buildpaneasync;
        //}
        //protected override void onnavigatedfrom(navigationeventargs e)
        //{
        //    //delete building "accountsettingspane"
        //    accountssettingspane.getforcurrentview().accountcommandsrequested -= buildpaneasync;
        //}
        ////authentication form building function
        //private async void buildpaneasync(accountssettingspane s, accountssettingspanecommandsrequestedeventargs e)
        //{
        //    var deferral = e.getdeferral();
        //    var msaprovider = await webauthenticationcoremanager.findaccountproviderasync("https://login.microsoft.com", "consumers");
        //    var command = new webaccountprovidercommand(msaprovider, getmsatokenasync);
        //    e.webaccountprovidercommands.add(command);
        //    deferral.complete();
        //}
        ////retrieving account data
        //public async void getmsatokenasync(webaccountprovidercommand command)
        //{
        //    webtokenrequest request = new webtokenrequest(command.webaccountprovider, "wl.basic");
        //    webtokenrequestresult result = await webauthenticationcoremanager.requesttokenasync(request);
        //    if (result.responsestatus == webtokenrequeststatus.success)
        //    {
        //        webaccount account = result.responsedata[0].webaccount;
        //        storewebaccount(account);
        //    }
        //}
        ////saving data in storage
        //private void storewebaccount(webaccount account)
        //{
        //    applicationdata.current.localsettings.values["currentuserproviderid"] = account.webaccountprovider.id;
        //    applicationdata.current.localsettings.values["currentuserid"] = account.id;
        //}

        private async void LoginItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.User = new User();
            LoginDialog dlg = new LoginDialog();
            var res = await dlg.ShowAsync();

            // checking if the dialog's opened successfully.
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsLoggedIn)
                {
                    MainFrame.Navigate(typeof(ViewGroupPage));
                }

            }
        }

        private async void RegistrationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.User = new User();
            RegisterDialog dlg = new RegisterDialog();
            var res = await dlg.ShowAsync();

            // checking if the dialog's opened successfully.
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsLoggedIn)
                {
                    MainFrame.Navigate(typeof(ViewGroupPage));
                }
            }
        }

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.LoggedUser = null;
        }
    }
}
