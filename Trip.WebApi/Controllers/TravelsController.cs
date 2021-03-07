using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Dtos;
using Trip.Core.Services;

namespace Trip.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelsController : ControllerBase
    {
        private readonly ILogger<TravelsController> _logger;
        private ITravelDomainService _travelDomainService;
        
        public TravelsController(ILogger<TravelsController> logger, ITravelDomainService travelDomainService)
        {
            _logger = logger;
            _travelDomainService = travelDomainService;
        }

        [HttpGet]
        public async Task<IEnumerable<TravelDto>> Get()
        {
            List<TravelDto> travelDtos = new List<TravelDto>();
            var travels = await _travelDomainService.GetTravels();
            travels.ToList().ForEach(p => travelDtos.Add(p.ToDto()));
            return travelDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public TravelDto Get(Guid id)
        {
            return new TravelDto() { Destination = "Warsaw" };
        }
    }
}
