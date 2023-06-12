using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using System.Net.Http.Json;

namespace Festifact.Web.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;

        public LocationService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<LocationDto> GetLocation(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Location", id));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(LocationDto);
                    }

                    return await response.Content.ReadFromJsonAsync<LocationDto>();
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

        public async Task<IEnumerable<LocationDto>> GetLocations()
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Location", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<LocationDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<LocationDto>>();
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

        public async Task<LocationDto> PostLocation(LocationToAddDto locationToAddDto)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Location", string.Empty));

            try
            {
                var response = await _client.PostAsJsonAsync<LocationToAddDto>(uri, locationToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(LocationDto);
                    }

                    return await response.Content.ReadFromJsonAsync<LocationDto>();

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
