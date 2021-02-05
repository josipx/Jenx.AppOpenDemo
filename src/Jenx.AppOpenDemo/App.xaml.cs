using Jenx.AppOpenDemo.Views;
using Xamarin.Forms;

namespace Jenx.AppOpenDemo
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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