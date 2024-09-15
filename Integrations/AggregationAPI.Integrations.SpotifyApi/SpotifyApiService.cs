//using AggregationAPI.Integration.SpotifyApi.Constants;
//using AggregationAPI.Integration.SpotifyApi.Models;
//using Microsoft.Extensions.Configuration;
//using System.Text;
//using System.Text.Json;


//namespace AggregationAPI.Integration.SpotifyApi
//{
//    public class SpotifyApiService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly IConfiguration _configuration;

//        private readonly string _baseUri = string.Empty;
//        private readonly string _authUri = string.Empty;
//        private readonly string _clientId = string.Empty;
//        private readonly string _clientSecret = string.Empty;

//        public SpotifyApiService(HttpClient httpClient, IConfiguration configuration)
//        {
//            _httpClient = httpClient;
//            _configuration = configuration;

//            _baseUri = configuration.GetSection("SpotifyApi:BaseUri").Value;
//            _authUri = configuration.GetSection("SpotifyApi:AuthUri").Value;
//            _clientId = configuration.GetSection("SpotifyApi:ClientId").Value;
//            _clientSecret = configuration.GetSection("SpotifyApi:ClientSecret").Value;
//        }

//        public async Task<Artist[]> GetSeveralArtistsAsync() 
//        {
//            var authorizationResponse = await AuthorizationAsync();

//            if (string.IsNullOrEmpty(authorizationResponse.Access_Token)) 
//            {
//                throw new Exception("Access Token is empty");
//            }

//            var endpoint = _baseUri + Endpoints.GetArtists;
//            var response = await _httpClient.GetAsync(endpoint);
//        }

//        private async Task<AuthorizationResponse> AuthorizationAsync()
//        {
//            var textBytes = Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}");
//            var authorizationHeader = Convert.ToBase64String(textBytes);

//            _httpClient.DefaultRequestHeaders.Add("Authorization", authorizationHeader);
//            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");

//            var tokenRequest = new Dictionary<string, string>()
//            {
//                {"grant_type", "client_credentials" }
//            };
//            var requestContent = new FormUrlEncodedContent(tokenRequest);

//            var endpoint = _authUri + Endpoints.Authorize;
//            var token = await _httpClient.PostAsync(endpoint, requestContent);

//            token.EnsureSuccessStatusCode();

//            var responseBody = await token.Content.ReadAsStringAsync();
//            var authorizationResponse = JsonSerializer.Deserialize<AuthorizationResponse>(responseBody);

//            return authorizationResponse;
//        }
//    }
//}
