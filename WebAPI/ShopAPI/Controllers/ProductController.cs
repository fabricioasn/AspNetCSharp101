using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopAPI.Models;
using ShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ShopAPI.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly DataContextShopDTO _context;
        public ProductController([FromServices] DataContextShopDTO context)
        {
            _context = context;
        }

        //read products as a list enumerable
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
            return Ok(products);
        }

        //get a product by ID
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _context.Products.AsNoTracking().Where(p => p.ID == id).FirstOrDefaultAsync();
            return Ok(products);
        }

        //read products as a list enumerable by category
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int Id)
        {
            var products = await _context.Products.AsNoTracking().Where(p => p.CategoryID == Id).ToListAsync();
            return Ok(products);
        }

        //create a new product
        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(product);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar a categoria." });
            }
        }

        //update an existing product
        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult<Product>> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.ID)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Entry<Product>(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Produto já atualizado." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }
        }

        //delete a product in database
        [Route("")]
        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ID == id);
            if (product == null)
            {
                return NotFound(new { message = "Produto não encontrado" });
            }
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o produto" });
            }
        }

    }
}
