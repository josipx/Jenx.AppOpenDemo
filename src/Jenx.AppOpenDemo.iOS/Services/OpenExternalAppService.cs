using System.Threading.Tasks;
using Jenx.AppOpenDemo.Services;
using Foundation;
using UIKit;

namespace Jenx.AppOpenDemo.iOS.Services
{
    public class OpenExternalAppService : IOpenExternalAppService
    {
        public Task<bool> LaunchApp(string uri)
        {
            try
            {
                var canOpen = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(uri));
                return Task.FromResult(canOpen && UIApplication.SharedApplication.OpenUrl(new NSUrl(uri)));
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}