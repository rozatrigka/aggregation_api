using System.Text;
using AggregationAPI.Integration.NewsApi.Models;
using System.Net.Http.Json;
using AggregationAPI.Integration.NewsApi.Constants;
using System.Web;

namespace AggregationAPI.Integration.NewsApi
{
    public class NewsApiService : INewsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NewsApiService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<ArticleResponse> GetArticlesAsync(ArticleRequest request) 
        {
            var url = GetRequestUrl(request);

           //it doesn't work for some reason
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
            var response = await _httpClient.GetAsync(url);
            
            //response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadFromJsonAsync<ArticleResponse>();

            return responseBody;
        }

        private string GetRequestUrl(ArticleRequest request) 
        {
            var strb = new StringBuilder();
            strb.Append(Endpoints.GetEverything);
            strb.Append("?");
            strb.Append("apiKey=");
            strb.Append(_apiKey);

            if (!string.IsNullOrEmpty(request.Question)) 
            {
                strb.Append("&");
                strb.Append("q=");
                strb.Append(HttpUtility.UrlEncode(request.Question));
            }

            return strb.ToString();
        }
    }
}
