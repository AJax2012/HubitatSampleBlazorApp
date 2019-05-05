using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HubitatSampleBlazorApp.Data
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HubitatApiInfo _info;

        public ApiService(IHttpClientFactory clientFactory, IOptions<HubitatApiInfo> info)
        {
            _clientFactory = clientFactory;
            _info = info.Value;
        }

        private string GetApiRequestUrl(string status, string deviceId)
        {
            var request = new StringBuilder();
            request.Append("/api/");
            request.Append(_info.RandomString);
            request.Append("/apps/");
            request.Append(_info.MakerApi);
            request.Append("/devices/");
            request.Append($"{deviceId}/");
            if (!string.IsNullOrEmpty(status))
            {
                request.Append($"/{status}/");
            }
            request.Append("?access_token=");
            request.Append(_info.AccessToken);
            return request.ToString();
        }

        public async Task<Light> ToggleSwitch(string status, string deviceId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                GetApiRequestUrl(status, deviceId));
            var client = _clientFactory.CreateClient("hubitat");
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Light>(responseString);
        }

        public async Task<string> GetSwitchStatus(string deviceId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                GetApiRequestUrl("", deviceId));
            var client = _clientFactory.CreateClient("hubitat");
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var light = JsonConvert.DeserializeObject<Light>(responseString);
            return light.Attributes.First().CurrentValue;
        }
    }
}
