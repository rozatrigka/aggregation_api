using AggregationAPI.Core.Abstractions;
using AggregationAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AggregationAPI.Host.Controllers
{
    [ApiController]
    [Route("aggregation/")]
    public class AggregationController : ControllerBase
    {
        private readonly IAggregationService _aggregationService;
        public AggregationController(IAggregationService aggregationService)
        {
            _aggregationService = aggregationService;
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetAsync(AggregationRequest request) 
        {
            var response = await _aggregationService.GetAsync(request);

            return Ok(response);
        }
    }
}
