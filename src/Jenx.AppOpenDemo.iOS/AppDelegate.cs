using Jenx.AppOpenDemo.iOS.Services;
using Jenx.AppOpenDemo.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Jenx.AppOpenDemo.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // register android type registration in DI container
            DependencyService.Register<IOpenExternalAppService, OpenExternalAppService>();

            Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}