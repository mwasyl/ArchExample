using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Ports.Driven;
using Microsoft.Azure.Cosmos;
using Trip.CosmosDB.DataAccess.Models;
using System.Linq;
using Trip.CosmosDB.DataAccess.Maps;

namespace Trip.CosmosDB.DataAccess
{
    public class TravelCosmosDbRepository : ITravelRepository
    {
        private Container _container;

        public TravelCosmosDbRepository(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IReadOnlyCollection<Travel>> Get()
        {
            var query = this._container.GetItemQueryIterator<TravelDal>();
            List<TravelDal> results = new List<TravelDal>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            List<Travel> travels = new List<Travel>();
            foreach(var travelDal in results)
            {
                travels.Add(TravelModelMapper.FromDalModel(travelDal));
            }

            return travels;
        }

        public async Task<Travel> Get(TravelId id)
        {
            try
            {
                ItemResponse<TravelDal> response = await this._container.ReadItemAsync<TravelDal>(id.Id.ToString(), new PartitionKey(id.Id.ToString()));
                var travelDal = response.Resource;
                return TravelModelMapper.FromDalModel(travelDal);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task Create(Travel travel)
        {
            var travelDal = TravelModelMapper.FromDomainModel(travel);
            await this._container.CreateItemAsync<TravelDal>(travelDal, new PartitionKey(travelDal.Id.ToString()));
        }

        public async Task Update(Travel travel)
        {
            var travelDal = TravelModelMapper.FromDomainModel(travel);
            await this._container.UpsertItemAsync<TravelDal>(travelDal, new PartitionKey(travelDal.Id.ToString()));
        }
    }
}
