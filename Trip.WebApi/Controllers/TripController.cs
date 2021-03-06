using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ILogger<TripController> _logger;
        private List<TripDto> _trips = new List<TripDto>();
        
        public TripController(ILogger<TripController> logger)
        {
            _logger = logger;
            _trips.Add(new TripDto() { Id = Guid.Parse("497469f3-1b41-4f82-8428-e7248cdfcd75"), Destination = "Lodz" });
            _trips.Add(new TripDto() { Id = Guid.Parse("df474c15-5fb9-4582-9cfe-e371a5b9ea2c"), Destination = "Warsaw" });
        }

        [HttpGet]
        public IEnumerable<TripDto> Get()
        {
            return _trips;
        }

        [HttpGet]
        [Route("{id}")]
        public TripDto Get(Guid id)
        {
            return _trips.FirstOrDefault(p => p.Id == id);
        }
    }
}
