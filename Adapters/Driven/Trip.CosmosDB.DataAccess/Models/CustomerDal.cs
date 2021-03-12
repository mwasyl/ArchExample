using Newtonsoft.Json;

namespace Trip.CosmosDB.DataAccess.Models
{
    public class CustomerDal
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string SurName { get; set; }
    }
}
