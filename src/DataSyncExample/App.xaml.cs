using DataSyncExample.Views;
using Xamarin.Forms;

namespace DataSyncExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // First approach - messy
            //MainPage = new MainPage_Everything();
            
            // second approach - reactive
            //MainPage = new MainPage_Basic();
            
            // third approach - reactive with bindable object
            MainPage = new MainPage();
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
