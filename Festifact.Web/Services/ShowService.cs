using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using System.Net.Http.Json;

namespace Festifact.Web.Services
{
    public class ShowService : IShowService
    {
        private readonly HttpClient _client;

        public ShowService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<ShowDto> GetShow(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Show", id));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ShowDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ShowDto>();
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

        public async Task<IEnumerable<ShowDto>> GetShows()
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Show", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ShowDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ShowDto>>();
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

        public async Task<ShowDto> PostShow(ShowToAddDto showToAddDto)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Show", string.Empty));

            try
            {
                var response = await _client.PostAsJsonAsync<ShowToAddDto>(uri, showToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ShowDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ShowDto>();

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
