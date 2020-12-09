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
        public MainViewModel()
        {
            Theme = ElementTheme.Light;
            SourceIconImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/moon.png"));
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isThemeLight(ElementTheme theme)
        {
            return theme == ElementTheme.Light;
        }

        internal void toggleTheme()
        {
            string absolutePathAssets = "ms-appx:///Assets/Icons/";
            Theme = isThemeLight(Theme) ? ElementTheme.Dark : ElementTheme.Light;
            SourceIconImage = isThemeLight(Theme) ?
                new BitmapImage(new Uri($"{absolutePathAssets}moon.png"))
                :
                new BitmapImage(new Uri($"{absolutePathAssets}sun.png"));
        }
    }
}
