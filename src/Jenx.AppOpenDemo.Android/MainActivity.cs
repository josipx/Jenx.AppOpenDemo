using Android.App;
using Android.Content.PM;
using Android.OS;
using Jenx.AppOpenDemo.Droid.Services;
using Jenx.AppOpenDemo.Services;
using Xamarin.Forms;

namespace Jenx.AppOpenDemo.Droid
{
    [Activity(Label = "Jenx AppOpenDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | 
        ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | 
        ConfigChanges.SmallestScreenSize )]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            // register android type registration in DI container
            DependencyService.Register<IOpenExternalAppService, OpenExternalAppService>();

            LoadApplication(new App());
        }
    }
}