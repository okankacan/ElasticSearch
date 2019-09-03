using ElasticSearch.Business.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business
{
    public class ElasticClientService : IElasticClientService
    {
        public async Task<ElasticClient> CreateElasticClient(string indexName, string uri)
        {
 
            var settings = new ConnectionSettings(new Uri(uri))
           .DefaultIndex(indexName);

            var _elasticClient = new ElasticClient(settings);

            return _elasticClient;
        }
    }
}
