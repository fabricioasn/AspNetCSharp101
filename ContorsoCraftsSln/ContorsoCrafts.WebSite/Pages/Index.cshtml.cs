using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContorsoCrafts.WebSite.Services;
using ContorsoCrafts.WebSite.Models;

//index backend Cs page

namespace ContorsoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //Json File Product service added at index startup
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger , JsonFileProductService productService)
        {
            _logger = logger;
            //indexModel constructor calling productService
            ProductService = productService;
        }

        //HttpGet method
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
