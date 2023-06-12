using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using System.Net.Http.Json;

namespace Festifact.Web.Services
{
    public class PerformerService : IPerformerService
    {
        private readonly HttpClient _httpClient;

        public PerformerService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<PerformerDto> GetPerformer(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Performer", id));

            try
            {
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(PerformerDto);
                    }

                    return await response.Content.ReadFromJsonAsync<PerformerDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<PerformerDto>> GetPerformers()
        {
        Uri uri = new Uri(string.Format(Constants.RestUrl, "Performer", string.Empty));

        try
        {
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<PerformerDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PerformerDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }
        }
        catch (Exception)
        {
            //Log exception
            throw;
        }
    }

        public async Task<PerformerDto> PostPerformer(PerformerToAddDto performerToAddDto)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Performer", string.Empty));

            try
            {
                var response = await _httpClient.PostAsJsonAsync<PerformerToAddDto>(uri, performerToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(PerformerDto);
                    }

                    return await response.Content.ReadFromJsonAsync<PerformerDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }   
    }
}
