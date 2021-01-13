using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DataSyncExample.Models;
using Xamarin.Forms;

namespace DataSyncExample.ViewModels
{
    public class MainViewModel_Everything : INotifyPropertyChanged
    {
        public MainViewModel_Everything()
        {
            Start = new Command(async () => await OnStartAsync());
        }
        
        public ICommand Start { get; }

        string title;

        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                    return;

                title = value;
                OnPropertyChanged();
            }
        }

        string header;
        public string Header
        {
            get => header;
            set
            {
                if (header == value)
                    return;

                header = value;
                OnPropertyChanged();
            }
        }

        string message;
        public string Message
        {
            get => message;
            set
            {
                if (message == value)
                    return;

                message = value;
                OnPropertyChanged();
            }
        }

        FontImageSource icon;
        public FontImageSource Icon
        {
            get => icon;
            set
            {
                if (icon == value)
                    return;

                icon = value;
                OnPropertyChanged();
            }
        }
        
        SyncStatus status;
        public SyncStatus Status
        {
            get => status;
            set
            {
                if (status == value)
                    return;

                status = value;
                OnPropertyChanged();
            }
        }

        async Task OnStartAsync()
        {
            Status = SyncStatus.Connecting;
            Update();
            await ConnectingAsync();

            Status = SyncStatus.Downloading;
            Update();
            await DownloadingAsync();

            Status = SyncStatus.Uploading;
            Update();
            await UploadingAsync();

            Status = SyncStatus.Success;
            Update();
        }

        Task ConnectingAsync() => Task.Delay(3000);
        Task DownloadingAsync() => Task.Delay(2000);
        Task UploadingAsync() => Task.Delay(2000);

        void Update()
        {
            // This was my original approach but became very difficult
            // to maintain. Instead make the screen reactive to the
            // Status property
            
            switch (Status)
            {
                case SyncStatus.Unknown:
                    break;
                case SyncStatus.Connecting:
                    Title = "Connecting";
                    Header = "@ahoefling";
                    Message = "Connecting to Server . . .";
                    Icon = new FontImageSource
                    {
                        Color = Color.Orange,
                        Size = 200,
                        Glyph = MaterialIconsFont.Information,
                        FontFamily = (OnPlatform<string>) Application.Current.Resources["MaterialIcons"]
                    };
                    break;
                case SyncStatus.Downloading:
                    Title = "Retrieving Data";
                    Header = "@ahoefling";
                    Message = "Downloading files from Server . . .";
                    Icon = new FontImageSource
                    {
                        Color = Color.Blue,
                        Size = 200,
                        Glyph = MaterialIconsFont.Download,
                        FontFamily = (OnPlatform<string>) Application.Current.Resources["MaterialIcons"]
                    };
                    break;
                case SyncStatus.Uploading:
                    Title = "Uploading";
                    Header = "@ahoefling";
                    Message = "Uploading files to Server . . .";
                    Icon = new FontImageSource
                    {
                        Color = Color.Blue,
                        Size = 200,
                        Glyph = MaterialIconsFont.Upload,
                        FontFamily = (OnPlatform<string>) Application.Current.Resources["MaterialIcons"]
                    };
                    break;
                case SyncStatus.Success:
                    Title = "Success";
                    Header = "@ahoefling";
                    Message = "All data is up to date!";
                    Icon = new FontImageSource
                    {
                        Color = Color.Green,
                        Size = 200,
                        Glyph = MaterialIconsFont.CheckCircle,
                        FontFamily = (OnPlatform<string>) Application.Current.Resources["MaterialIcons"]
                    };
                    break;
                case SyncStatus.Failure:
                    Title = "Failure";
                    Header = "@ahoefling";
                    Message = "Failed to connect to server!";
                    Icon = new FontImageSource
                    {
                        Color = Color.Red,
                        Size = 200,
                        Glyph = MaterialIconsFont.CloseCircle,
                        FontFamily = (OnPlatform<string>) Application.Current.Resources["MaterialIcons"]
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}