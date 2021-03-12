using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Ports.Driven;
using Trip.CosmosDB.DataAccess.Maps;
using Trip.CosmosDB.DataAccess.Models;

namespace Trip.CosmosDB.DataAccess
{
    public class CustomerCosmosDbRepository : ICustomerRepository
    {
        private Container _container;

        public CustomerCosmosDbRepository(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task Create(Customer customer)
        {
            var customerDal = CustomerModelMapper.FromDomainModel(customer);
            await this._container.CreateItemAsync<CustomerDal>(customerDal, new PartitionKey(customerDal.Id.ToString()));
        }

        public async Task<Customer> Get(UserId id)
        {
            try
            {
                ItemResponse<CustomerDal> response = await this._container.ReadItemAsync<CustomerDal>(id.ToString(), new PartitionKey(id.ToString()));
                var customerDal = response.Resource;
                return CustomerModelMapper.FromDalModel(customerDal);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task Update(Customer customer)
        {
            var customerDal = CustomerModelMapper.FromDomainModel(customer);
            await this._container.UpsertItemAsync<CustomerDal>(customerDal, new PartitionKey(customerDal.Id.ToString()));
        }

        public async Task<IReadOnlyCollection<Customer>> Get()
        {
            var query = this._container.GetItemQueryIterator<CustomerDal>();
            List<CustomerDal> results = new List<CustomerDal>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            List<Customer> customers = new List<Customer>();
            foreach (var customerDal in results)
            {
                customers.Add(CustomerModelMapper.FromDalModel(customerDal));
            }

            return customers;
        }
    }
}
