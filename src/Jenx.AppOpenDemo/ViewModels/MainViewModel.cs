using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Jenx.AppOpenDemo.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Jenx.AppOpenDemo.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            // Missing out-of-the-box constructor injection in XF
            // use fx which support this, e.g. Prism, AutoFac, etc...
            var openExternalAppService = DependencyService.Get<IOpenExternalAppService>();

            OpenExternalAppCommand = new Command(async () =>
            {
                try
                {
                    if(!await openExternalAppService.LaunchApp(Device.RuntimePlatform == Device.iOS ? 
                        "nflx://" : 
                        "com.netflix.mediaclient"))
                    {
                        await TryLaunchingNetflixWebAsync();
                    }
                }
                catch
                {
                    await TryLaunchingNetflixWebAsync();
                }
            });
        }

        public ICommand OpenExternalAppCommand { get; }

        private Task TryLaunchingNetflixWebAsync()
        {
            return Launcher.TryOpenAsync(
                Device.RuntimePlatform == Device.iOS ?
                    new Uri("https://apps.apple.com/us/app/netflix/id363590051") :
                    new Uri("https://play.google.com/store/apps/details?id=com.netflix.mediaclient"));
        }
    }
}