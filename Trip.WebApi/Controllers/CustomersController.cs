using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Dtos;
using Trip.Core.Services;

namespace Trip.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<TravelsController> _logger;
        private readonly IDomainCustomerService _domainCustomerService;

        public CustomersController(ILogger<TravelsController> logger, 
            IDomainCustomerService domainCustomerService)
        {
            _logger = logger;
            _domainCustomerService = domainCustomerService;
        }

        //Get all
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get()
        {
            List<CustomerDto> customersDtos = new List<CustomerDto>();
            var customers = await _domainCustomerService.GetCustomers();
            customers.ToList().ForEach(p => customersDtos.Add(p.ToDto()));
            return customersDtos;
        }

        //Get by id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(Guid id)
        {
            try
            {
                var customer = await _domainCustomerService.GetCustomer(new UserId(id));
                if (customer == null)
                {
                    return NotFound();
                }
                return customer.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while gathering customer: {id}", ex);
                throw;
            }
        }

        //Create
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Post(CustomerDto customerDto)
        {
            var customer = Customer.FromDto(customerDto);
            await _domainCustomerService.CreateCustomer(customer);
            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }

        //Edit
        [HttpPatch]
        public async Task<ActionResult> Patch(CustomerDto customerDto)
        {
            try
            {
                _domainCustomerService.EditCustomer(customerDto.Id, Customer.FromDto(customerDto));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while editting customer: {customerDto.Id}", ex);
                throw;
            }
        }
    }
}
