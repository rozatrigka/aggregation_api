using AggregationAPI.Integration.NewsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.NewsApi
{
    public interface INewsApiService
    {
        Task<ArticleResponse> GetArticlesAsync(ArticleRequest request);
    }
}
