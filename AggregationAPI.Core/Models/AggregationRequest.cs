using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Core.Models
{
    public class AggregationRequest
    {
        public PolutionRequest? Polution { get; set; }

        public NewsRequest? News { get; set; }
    }
}
