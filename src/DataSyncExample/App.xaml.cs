using System.Globalization;
using DataSyncExample.Resx;
using DataSyncExample.Views;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace DataSyncExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // First approach - messy
            MainPage = new MainPage_Everything();
            
            #region second
            // second approach - reactive
            //MainPage = new MainPage_Basic();
            #endregion

            #region third
            // third approach - reactive with bindable object
            // LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            // LocalizationResourceManager.Current.SetCulture(new CultureInfo("es"));
            // MainPage = new MainPage();
            #endregion
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
