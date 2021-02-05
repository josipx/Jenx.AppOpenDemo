using System.Threading.Tasks;

namespace Jenx.AppOpenDemo.Services
{
    public interface IOpenExternalAppService
    {
        Task<bool> LaunchApp(string uri);
    }
}
