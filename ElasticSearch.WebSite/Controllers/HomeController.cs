using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ElasticSearch.WebSite.Models;
using ElasticSearch.Business.Models;
using ElasticSearch.Business.Interface;
using Nest;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ElasticSearch.WebSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IAutocompleteService _autocompleteService;
        private readonly IConfiguraionIndex _configuraionIndex;
        private readonly IProductService _productService;

        public HomeController(IConfiguration configuration, IAutocompleteService autocompleteService, IConfiguraionIndex configuraionIndex, IProductService productService)
        {
            _configuration = configuration;
            _autocompleteService = autocompleteService;
            _configuraionIndex = configuraionIndex;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {

            var products = await  _productService.CreateProductListAsync();


            bool isCreated = _autocompleteService.CreateIndexAsync(_configuraionIndex.productSuggestIndex, _configuraionIndex.uri).Result;

            if (isCreated)
            {
                _autocompleteService.IndexAsync(_configuraionIndex.productSuggestIndex, products, _configuraionIndex.uri).Wait();
            }


                    return View();
        }

        public async Task<IActionResult> SearchProduct(string keyword)
        {

            var result = await _autocompleteService.SuggestAsync(_configuraionIndex.productSuggestIndex, keyword, _configuraionIndex.uri);
  

            return Ok(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
