using System;
using System.Globalization;
using DataSyncExample.Models;
using Xamarin.Forms;

namespace DataSyncExample.Converters
{
    public class SyncStatusConverter : BindableObject, IValueConverter
    {
        public static readonly BindableProperty ConnectingProperty =
            BindableProperty.Create(nameof(Connecting), typeof(object), typeof(SyncStatusConverter));

        public static readonly BindableProperty DownloadingProperty =
            BindableProperty.Create(nameof(Downloading), typeof(object), typeof(SyncStatusConverter));

        public static readonly BindableProperty UploadingProperty =
            BindableProperty.Create(nameof(Uploading), typeof(object), typeof(SyncStatusConverter));

        public static readonly BindableProperty SuccessProperty =
            BindableProperty.Create(nameof(Success), typeof(object), typeof(SyncStatusConverter));

        public static readonly BindableProperty FailureProperty =
            BindableProperty.Create(nameof(Failure), typeof(object), typeof(SyncStatusConverter));

        public object Connecting
        {
            get => GetValue(ConnectingProperty);
            set => SetValue(ConnectingProperty, value);
        }

        public object Downloading
        {
            get => GetValue(DownloadingProperty);
            set => SetValue(DownloadingProperty, value);
        }

        public object Uploading
        {
            get => GetValue(UploadingProperty);
            set => SetValue(UploadingProperty, value);
        }

        public object Success
        {
            get => GetValue(SuccessProperty);
            set => SetValue(SuccessProperty, value);
        }

        public object Failure
        {
            get => GetValue(FailureProperty);
            set => SetValue(FailureProperty, value);
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (SyncStatus) value;
            switch (status)
            {
                case SyncStatus.Connecting:
                    return Connecting;
                case SyncStatus.Downloading:
                    return Downloading;
                case SyncStatus.Uploading:
                    return Uploading;
                case SyncStatus.Success:
                    return Success;
            }

            return Failure;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}