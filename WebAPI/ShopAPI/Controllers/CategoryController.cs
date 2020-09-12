using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopAPI.Models;
using ShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// https://localhost:5001/v1/categories local
// https://myapp.azurewebsites.net azure


namespace ShopAPI.Controllers
{
    [Route("v1/[controller]")]
    public class CategoryController : Controller
    {

        private readonly DataContextShopDTO _context;
        public CategoryController(DataContextShopDTO context)
        {
            _context = context;
        }

        //read categories as a list enumerable
        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        //get a category by ID
        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category GetCategory(int id)
        {
            return _context.Categories.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

        //get a product by ID
        [Route("v1/products/{id}")]
        [HttpGet]
        public Product GetProduct(int id)
        {
            return _context.Products.AsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }

        //read products as a list enumerable by category
        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int Id)
        {
            return _context.Products.AsNoTracking().Where(p => p.CategoryID == Id).ToList();
        }

        //create a new category
        [Route("v1/categories")]
        [HttpPost]
        public Category PostCategory([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        //create a new product
        [Route("v1/products")]
        [HttpPost]
        public Product PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        //uptade an existing category
        [Route("v1/categories")]
        [HttpPut]
        public Category PutCategory([FromBody]Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        //update an existing product
        [Route("v1/products")]
        [HttpPut]
        public Product PutProduct([FromBody] Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();

            return product;
        }

        //delete a category in database
        [Route("v1/categories")]
        [HttpDelete]
        public Category DeleteCategory([FromBody]Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }

        //delete a product in database
        [Route("v1/products")]
        [HttpDelete]
        public Product DeleteProduct([FromBody] Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }

    }
}
