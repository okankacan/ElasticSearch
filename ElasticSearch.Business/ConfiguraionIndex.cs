using ElasticSearch.Business.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business
{
    public class ConfiguraionIndex : IConfiguraionIndex
    {
        public  string productSuggestIndex { get; }
        public string uri { get; }

        public ConfiguraionIndex(IConfiguration _configuration)
        {
            this.productSuggestIndex = _configuration.GetSection("ElasticSearcData:productSuggestIndex").Value;
            this.uri = _configuration.GetSection("ElasticSearcData:uri").Value;
        }
    }
}
