using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MemoMap.UWP.ViewModels
{
    public class MainViewModel : BindableBase
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
        {
            get => _pageTitle;
            set => SetField(ref _pageTitle, value);
        }
        public BitmapImage SourceIconImage
        {
            get => _sourceAttribute;
            set => SetField(ref _sourceAttribute, value);
        }

        public ElementTheme Theme
        {
            get => _theme;
            set => SetField(ref _theme, value);
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


        internal async Task<StorageFile> PickImageFileAsync()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile file = await openPicker.PickSingleFileAsync();
            return file;
        }

        internal async Task<BitmapImage> LoadImageFile(StorageFile file)
        {
            var stream = await file.OpenAsync(FileAccessMode.Read);
            BitmapImage image = new BitmapImage();
            image.SetSource(stream);

            return image;
        }

        internal async Task<byte[]> LoadFileByteArray(StorageFile file)
        {
            if (file != null)
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    byte[] content = new byte[stream.Length];
                    await stream.ReadAsync(content, 0, content.Length);
                    return content;
                }
            }
            return null;
        }

        
    }
}
