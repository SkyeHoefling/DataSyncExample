namespace DataSyncExample.Models
{
    public enum SyncStatus
    {
        Unknown = -1,
        Connecting = 1,
        Downloading = 2,
        Uploading = 3,
        Success = 4,
        Failure = 5
    }
}