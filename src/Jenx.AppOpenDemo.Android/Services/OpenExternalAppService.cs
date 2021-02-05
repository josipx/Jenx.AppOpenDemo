using System.Threading.Tasks;
using Android.Content;
using Android.Content.PM;
using Jenx.AppOpenDemo.Services;
using Application = Android.App.Application;

namespace Jenx.AppOpenDemo.Droid.Services
{
    public class OpenExternalAppService : IOpenExternalAppService
    {
        public Task<bool> LaunchApp(string packageName)
        {
            var result = false;

            try
            {
                var pm = Application.Context.PackageManager;

                if (pm != null && IsAppInstalled(packageName))
                {
                    var intent = pm.GetLaunchIntentForPackage(packageName);
                    if (intent != null)
                    {
                        intent.SetFlags(ActivityFlags.NewTask);
                        Application.Context.StartActivity(intent);
                        result = true;
                    }
                }
            }
            catch
            {
                // something went wrong...
            }

            return Task.FromResult(result);
        }

        private static bool IsAppInstalled(string packageName)
        {
            var installed = false;

            try
            {
                var pm = Application.Context.PackageManager;

                if (pm != null)
                {
                    pm.GetPackageInfo(packageName, PackageInfoFlags.Activities);
                    installed = true;
                }
            }
            catch
            {
                // something went wrong...
            }

            return installed;
        }
    }
}