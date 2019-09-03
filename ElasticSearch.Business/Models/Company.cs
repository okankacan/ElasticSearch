using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Models
{
   

    //public abstract class Document
    //{
    //    public Nest.JoinField Join { get; set; }
    //}

    //public class Company : Document
    //{
    //    public string Name { get; set; }
    //    public List<Product> Employees { get; set; }
    //}

    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompletionField Suggest { get; set; }
    }
}
