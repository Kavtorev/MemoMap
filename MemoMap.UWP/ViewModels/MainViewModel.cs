using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MemoMap.UWP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ElementTheme _theme;
        private BitmapImage _sourceAttribute;
        private string _pageTitle;
        private static string absolutePathIcons;

        public MainViewModel()
        {
            Theme = ElementTheme.Light;
            absolutePathIcons = "ms-appx:///Assets/Icons/";
            SourceIconImage = new BitmapImage(new Uri($"{absolutePathIcons}moon.png"));
            PageTitle = "Home page";
        }
        public string PageTitle 
        {   get 
            {
                return _pageTitle;
            } 
            set 
            {
                _pageTitle = value;
                OnPropertyChanged();
            } 
        }
        public BitmapImage SourceIconImage 
        {
            get 
            {
                return _sourceAttribute;
            }
            set 
            {
                _sourceAttribute = value;
                // triggers PropertyChanged event in order to rerender the UI
                OnPropertyChanged();
            } 
        }

        public ElementTheme Theme 
        {
            get 
            {
                return _theme;
            } 
            set 
            {
                _theme = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // [CallerMemberName] - attribute which obtains a property name of the caller
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isThemeLight(ElementTheme theme)
        {
            return theme == ElementTheme.Light;
        }

        // toggleTheme - changes properties' values ( Theme, SourceIconImage )
        internal void toggleTheme()
        {
            Theme = isThemeLight(Theme) ? ElementTheme.Dark : ElementTheme.Light;
            SourceIconImage = isThemeLight(Theme) ?
                new BitmapImage(new Uri($"{absolutePathIcons}moon.png"))
                :
                new BitmapImage(new Uri($"{absolutePathIcons}sun.png"));
        }

        internal void setTitle(string pageTitle)
        {
            PageTitle = pageTitle;
        }
    }
}
