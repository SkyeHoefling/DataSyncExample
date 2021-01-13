using System;
using System.Globalization;
using DataSyncExample.Models;
using Xamarin.Forms;

namespace DataSyncExample.Converters
{
    public class SyncStatusConverter_Basic : IValueConverter
    {
        public object Connecting { get; set; }
        public object Downloading { get; set; }
        public object Uploading { get; set; }
        public object Success { get; set; }
        public object Failure { get; set; }
        
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