using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
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
        public async Task<ActionResult<TravelDto>> Get(Guid id)
        {
            try
            {
                var travel = await _travelDomainService.GetTravel(new TravelId(id));
                if (travel == null)
                {
                    return NotFound();
                }
                return travel.ToDto();
            } catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<TravelDto>> Post(TravelDto travelDto)
        {
            var travel = Travel.FromDto(travelDto);
            await _travelDomainService.CreateTravel(travel);
            return CreatedAtAction("Get", new { id = travel.Id }, travel);
        }

        [HttpPut]
        public async Task<ActionResult<TravelDto>> Put(TravelDto travelDto)
        {
            try
            {
                _travelDomainService.EditTravel(travelDto.Id, Travel.FromDto(travelDto));
                return NoContent();
            } catch(Exception ex)
            {
                throw;
            }
        }
    }
}
