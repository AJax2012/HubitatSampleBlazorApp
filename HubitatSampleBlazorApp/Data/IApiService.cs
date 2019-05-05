using System.Threading.Tasks;

namespace HubitatSampleBlazorApp.Data
{
    public interface IApiService
    {
        Task<Light> ToggleSwitch(string status, string deviceId);
        Task<string> GetSwitchStatus(string deviceId);
    }
}