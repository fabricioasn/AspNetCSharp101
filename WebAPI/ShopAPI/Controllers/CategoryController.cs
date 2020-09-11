using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ShopAPI.Models;
using ShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// https://localhost:5001/categories local
// https://myapp.azurewebsites.net azure


namespace ShopAPI.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        [Route("")]
        public string MyMethod()
        {
            return "Test API";
        }
        private readonly DataContextShopDTO _context;
        public CategoryController(DataContextShopDTO context)
        {
            _context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }
    }
}
