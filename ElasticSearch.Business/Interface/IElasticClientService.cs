using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Interface
{
    public interface IElasticClientService
    {
        Task<ElasticClient> CreateElasticClient(string indexName , string uri);
    }
}
