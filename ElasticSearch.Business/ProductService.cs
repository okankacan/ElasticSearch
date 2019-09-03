using ElasticSearch.Business.Interface;
using ElasticSearch.Business.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business
{
    public class ProductService : IProductService

    {
        public async Task<List<Product>> CreateProductListAsync()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = 1,
                Name = "Samsung Galaxy Note 8",
                Suggest = new CompletionField()
                {
                    Input = new[] { "Samsung Galaxy Note 8", "Galaxy Note 8", "Note 8" }
                }
            });

            products.Add(new Product()
            {
                Id = 2,
                Name = "Samsung Galaxy S8",
                Suggest = new CompletionField()
                {
                    Input = new[] { "Samsung Galaxy S8", "Galaxy S8", "S8" }
                }
            });

            products.Add(new Product()
            {
                Id = 3,
                Name = "Apple Iphone 8",
                Suggest = new CompletionField()
                {
                    Input = new[] { "Apple Iphone 8", "Iphone 8" }
                }
            });

            products.Add(new Product()
            {
                Id = 4,
                Name = "Apple Iphone X",
                Suggest = new CompletionField()
                {
                    Input = new[] { "Apple Iphone X", "Iphone X" }
                }
            });

            products.Add(new Product()
            {
                Id = 5,
                Name = "Apple iPad Pro",
                Suggest = new CompletionField()
                {
                    Input = new[] { "Apple iPad Pro", "iPad Pro" }
                }
            });

            return  products;
        }
    }
}
