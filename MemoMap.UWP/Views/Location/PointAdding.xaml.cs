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
using MemoMap.UWP.ViewModels;


namespace MemoMap.UWP.Views.Location
{
    public sealed partial class PointAdding : ContentDialog
    {
        internal string pointname;

        public NoteViewModel NoteViewModel { get; set; }


        public PointAdding()
        {
            this.InitializeComponent();
            NoteViewModel = new NoteViewModel();
        }

        private void SavePointClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            pointname = PointName.Text;
        }

        private void CancelPointAddingClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PointName.Text = ""; // clear the text of pointname to exit from MemoMap_MapTapped properly
        }
    }
}
