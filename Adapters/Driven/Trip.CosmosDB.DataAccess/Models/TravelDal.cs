using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Trip.CosmosDB.DataAccess.Models
{
    public class TravelDal
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        [JsonProperty(PropertyName = "isCancel")]
        public bool IsCancel { get; set; }

        public List<CustomerDal> Customers { get; set; }
    }
}
