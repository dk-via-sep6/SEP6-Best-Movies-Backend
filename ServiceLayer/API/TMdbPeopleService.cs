using DomainLayer.Entities;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;

namespace ServiceLayer.API
{
    public class TMdbPeopleService : ITMdbPeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _bearerToken;
        private readonly string _apiBaseUrl = "https://api.themoviedb.org/3";

        public TMdbPeopleService(IHttpClientFactory httpClientFactory, string token)
        {
            _httpClient = httpClientFactory.CreateClient();
            _bearerToken = token;
        }
        public async Task<PeopleDomain> GetTrendingAsync()
        {
            var requestUri = $"{_apiBaseUrl}/trending/person/week?language=en-US";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var trendingResponse = JsonConvert.DeserializeObject<PeopleDomain>(content);

            return trendingResponse;
        }
    }
}