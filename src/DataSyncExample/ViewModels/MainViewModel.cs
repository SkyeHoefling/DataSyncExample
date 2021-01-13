using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DataSyncExample.Models;
using Xamarin.Forms;

namespace DataSyncExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Start = new Command(async () => await OnStartAsync());
        }
        public ICommand Start { get; }
        
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
            await ConnectingAsync();

            Status = SyncStatus.Downloading;
            await DownloadingAsync();

            Status = SyncStatus.Uploading;
            await UploadingAsync();

            Status = SyncStatus.Success;
        }

        Task ConnectingAsync() => Task.Delay(3000);
        Task DownloadingAsync() => Task.Delay(2000);
        Task UploadingAsync() => Task.Delay(2000);
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}