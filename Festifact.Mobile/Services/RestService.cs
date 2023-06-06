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
        public List<Show> Shows { get; private set; }

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

            Uri uri = new Uri(string.Format(Constants.RestUrl, "Festival", string.Empty));

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

        public async Task SaveTicketAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Ticket", string.Empty));

            try
            {
                var jsonTicket = new Dictionary<string, object>()
                {
                    { "FestivalId", id } 
                };
                string json = JsonSerializer.Serialize(jsonTicket, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTicket successfully saved.");
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<User> RefreshUserAsync(int id)
        {
            User user = null;
            Uri uri = new Uri(string.Format(Constants.RestUrl, "User", id));

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<User>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return user;
        }

        public Task SaveFestivalItemAsync(Festival festival, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFestivalItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveUserAsync(User user, bool isNewUser = false)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "User", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<User>(user, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewUser)
                    response = await _httpClient.PostAsync(uri, content);
                else
                    response = await _httpClient.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tUser successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }

        public async Task<List<Show>> RefreshShowsAsync()
        {
            Shows = new List<Show>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, "Show", string.Empty));

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Shows = JsonSerializer.Deserialize<List<Show>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Shows;
        }
    }
}
