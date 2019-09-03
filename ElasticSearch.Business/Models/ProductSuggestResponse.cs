using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Models
{
    public class ProductSuggestResponse
    {
        public IEnumerable<ProductSuggest> Suggests { get; set; }      
    }
    public class ProductSuggest
    {

        public int Id { get; set; }
        public string Name { get; set; }
       // public double Score { get; set; }
    }
}
