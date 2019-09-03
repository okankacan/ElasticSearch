using ElasticSearch.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Interface
{
    public interface IProductService
    {
        Task<List<Product>> CreateProductListAsync();
    }
}
