using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.NewsApi.Models
{
    public class ArticleResponse
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public Article[] Articles {get; set;}


    }
}
