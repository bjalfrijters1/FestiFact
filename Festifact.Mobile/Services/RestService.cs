using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class RestService : IRestService
    {

        HttpClient _httpClient;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public List<Festival> Festivals { get; private set; }

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if(handler != null)
            {
                _httpClient = new HttpClient(handler);
            } else
            {
                _httpClient = new HttpClient();
            }
#else
            _httpClient = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }

        public async Task<List<Festival>> RefreshDataAsync()
        {
            Festivals = new List<Festival>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Festivals = JsonSerializer.Deserialize<List<Festival>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Festivals;
        }

        public Task SaveFestivalItemAsync(Festival festival, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFestivalItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
