using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Dtos;
using Trip.Core.Exceptions;
using Trip.Core.Services;

namespace Trip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelsController : ControllerBase
    {
        private readonly ILogger<TravelsController> _logger;
        private IDomainTravelService _travelDomainService;
        
        public TravelsController(ILogger<TravelsController> logger, IDomainTravelService travelDomainService)
        {
            _logger = logger;
            _travelDomainService = travelDomainService;
        }

        //Get all
        [HttpGet]
        public async Task<IEnumerable<TravelDto>> Get()
        {
            List<TravelDto> travelDtos = new List<TravelDto>();
            var travels = await _travelDomainService.GetTravels();
            travels.ToList().ForEach(p => travelDtos.Add(p.ToDto()));
            return travelDtos;
        }

        //Get by id
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
                _logger.LogError($"Error while gathering travel: {id}", ex);
                throw;
            }
        }

        //Create
        [HttpPost]
        public async Task<ActionResult<TravelDto>> Post(TravelDto travelDto)
        {
            var travel = Travel.FromDto(travelDto);
            await _travelDomainService.CreateTravel(travel);
            return CreatedAtAction("Get", new { id = travel.Id }, travel);
        }

        //Edit
        [HttpPatch]
        public async Task<ActionResult<TravelDto>> Patch(TravelDto travelDto)
        {
            if (!travelDto.Id.HasValue)
            {
                return NotFound();
            }
            await _travelDomainService.EditTravel(travelDto.Id.Value, Travel.FromDto(travelDto));
            return CreatedAtAction("Patch", new { id = travelDto.Id }, travelDto);
        }

        //assign customer
        [HttpPatch]
        [Route("assign-customer")]
        public async Task<ActionResult> AssignCustomer(TravelDto travelDto)
        {
            try
            {
                if (travelDto.Id.HasValue && travelDto.CustomerId.HasValue)
                {
                    await _travelDomainService.AssignCustomer(new TravelId(travelDto.Id.Value), new UserId(travelDto.CustomerId.Value));
                    return NoContent();
                } else
                {
                    throw new TravelException("No travel id or customer id.");
                }
            } catch(Exception ex)
            {
                _logger.LogError($"Error while assigning customer to travel: {travelDto.Id}", ex);
                throw;
            }
        }

        //cancel
        [HttpPatch]
        [Route("cancel")]
        public async Task<ActionResult> Cancel(TravelDto travelDto)
        {
            try
            {
                if (travelDto.Id.HasValue)
                {
                    await _travelDomainService.Cancel(new TravelId(travelDto.Id.Value));
                    return NoContent();
                }
                else
                {
                    throw new TravelException("No travel id");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while cancelling a travel: {travelDto.Id}", ex);
                throw;
            }
        }
    }
}
