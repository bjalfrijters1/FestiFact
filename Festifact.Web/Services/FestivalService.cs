using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using System.Net.Http.Json;

namespace Festifact.Web.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly HttpClient _client;

        public FestivalService(HttpClient _client)
        {
            this._client = _client;
        }
        public async Task<FestivalDto> GetFestival(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Festival", id));

            try
            {
                var response = await _client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FestivalDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FestivalDto>();
                } else
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

        public async Task<IEnumerable<FestivalDto>> GetFestivals()
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Festival", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FestivalDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<FestivalDto>>();
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

        public async Task<FestivalDto> PostFestival(FestivalToAddDto festivalToAdd)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Festival", string.Empty));

            try
            {
                var response = await _client.PostAsJsonAsync<FestivalToAddDto>(uri, festivalToAdd);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FestivalDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FestivalDto>();

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

        public async Task<FestivalDto> PutFestival(FestivalDto festival)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Festival", string.Empty));

            try
            {
                var response = await _client.PutAsJsonAsync<FestivalDto>(uri, festival);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FestivalDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FestivalDto>();

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
