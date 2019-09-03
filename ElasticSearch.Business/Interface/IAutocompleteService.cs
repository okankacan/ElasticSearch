using ElasticSearch.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Interface
{
    public interface IAutocompleteService
    {
        Task<bool> CreateIndexAsync(string indexName, string uri);

        Task<bool> DeleteIndexAsync(string indexName, string uri);
        Task IndexAsync(string indexName, List<Product> products, string uri);
        Task<ProductSuggestResponse> SuggestAsync(string indexName, string keyword, string uri);

       
    }
}
