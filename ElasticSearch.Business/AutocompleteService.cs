
using Elasticsearch.Net;
using ElasticSearch.Business.Interface;
using ElasticSearch.Business.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business
{
    public class AutocompleteService : IAutocompleteService
    {

        private readonly IElasticClientService _elasticClientService;
        public AutocompleteService(IElasticClientService elasticClientService)
        {
            _elasticClientService = elasticClientService;
        }

        public async Task<bool> CreateIndexAsync(string indexName, string uri)
        {
            var _elasticClient = await _elasticClientService.CreateElasticClient(indexName, uri);
            if (_elasticClient.Indices.Exists(indexName.ToLowerInvariant()).Exists)
            {
                return false;
  
            }

            return true;


        }

        public async Task<bool> DeleteIndexAsync(string indexName, string uri)
        {
            var _elasticClient = await _elasticClientService.CreateElasticClient(indexName, uri);
            if (_elasticClient.Indices.Exists(indexName.ToLowerInvariant()).Exists)
            {

                _elasticClient.Indices.Delete(indexName.ToLowerInvariant());

            }
           return true;
        }

        public async Task IndexAsync(string indexName, List<Product> products, string uri)
        {

            var _elasticClient = await _elasticClientService.CreateElasticClient(indexName, uri);

     
            foreach (var item in products)
            {

                var result=   _elasticClient.Index<Product>(item, c=>c.Index(indexName));
 
            }

        }

        public async Task<ProductSuggestResponse> SuggestAsync(string indexName, string keyword, string uri)
        {

        
               var _elasticClient = await _elasticClientService.CreateElasticClient(indexName, uri);

            var searchResponse = _elasticClient.Search<Product>(s => s
               .From(0)
               .Size(10)
               .Query(q => q
                    .Match(m => m
                       .Field(f => f.Name)
                       .Query(keyword.ToString())
                    )
               )
           );
 

            var productList = new List<ProductSuggest>();
            foreach(var item in searchResponse.Documents)
            {
                productList.Add(new ProductSuggest { Id = item.Id, Name = item.Name });
            }
            

 

            return new ProductSuggestResponse
            {
                Suggests = productList
            };
 

 
        }
    }
}

