using MemoMap.Domain.Models;
using MemoMap.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoMap.UWP.Views.GroupViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateGroupPage : Page
    {
        public GroupViewModel GroupViewModel { get; set; }
        private string _mode;
        private Group _entityToEdit;
        public CreateGroupPage()
        {
            this.InitializeComponent();
            GroupViewModel = new GroupViewModel();
            _mode = "creation";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var dictParam = (Dictionary<string, object>)e.Parameter;

                if (
                    dictParam.ContainsKey("mode") &&
                    dictParam.ContainsKey("object") &&
                    dictParam.TryGetValue("object", out object entity) &&
                    dictParam.TryGetValue("mode", out object mode)
                    )
                {
                    _mode = (string)mode;
                    _entityToEdit = (Group)entity;

                    GroupViewModel.Group = _entityToEdit;

                }
            }
            base.OnNavigatedTo(e);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == "creation")
            {
                await GroupViewModel.InsertAsync();
            } else
            {
                await GroupViewModel.EditAsync();
            }

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

      
    }
}
