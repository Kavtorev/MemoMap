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
using MemoMap.UWP.Views.LocationViews;
using MemoMap.UWP.Views.AccountSettings;
using MemoMap.UWP.ViewModels;
using Windows.UI.ApplicationSettings;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using MemoMap.UWP.Views.UserViews;
using MemoMap.UWP.Views.MapViews;
using MapPage = MemoMap.UWP.Views.LocationViews.MapPage;
using MemoMap.UWP.Views.InvitationViews;
using MemoMap.Domain;
using MemoMap.UWP.Views.TemporaryViews;
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
            MainViewModel = App.MainViewModel;
            UserViewModel = App.UserViewModel;
            GoBackButton.Frame = MainFrame;
        }

        // include new routes for pages here
        private void InitializeRoutes()
        {
            // key - value pairs: <title of a page>  - <its data type>.
            Routes = new Dictionary<string, Type>
            {
                {"Your Maps List",  typeof(ViewMapsPage)},
                {"Originate a new group",  typeof(CreateGroupPage)},
                {"Your group list",  typeof(ViewGroupPage)},
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
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(HomePage));
            MainViewModel.LoadTheNumberOfInvites();
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

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.LoggedUser = null;
            App.GlobalRootFrame.Navigate(typeof(BlankPage));
        }
    }
}
