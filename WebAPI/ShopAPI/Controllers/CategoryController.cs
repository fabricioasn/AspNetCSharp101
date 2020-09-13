using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopAPI.Models;
using ShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ShopAPI.Data;
using System;

// https://localhost:5001/v1/categories local
// https://myapp.azurewebsites.net azure



[Route("v1/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly DataContextShopDTO _context;
        public CategoryController(DataContextShopDTO context)
        {
            _context = context;
        }

        //read categories as a list enumerable
        [Route("v1/categories")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        //get a category by ID
        [Route("v1/categories/{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return _context.Categories.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

        //get a product by ID
        [Route("v1/products/{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return _context.Products.AsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }

        //read products as a list enumerable by category
        [Route("v1/categories/{id:int}/products")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int Id)
        {
            return _context.Products.AsNoTracking().Where(p => p.CategoryID == Id).ToList();
        }

        //create a new category
        [Route("v1/categories")]
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(
            [FromBody]Category category,
            [FromServices]DataContextShopDTO dataContext)
        {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível criar a categoria." });
        }
        
        }

        //create a new product
        [Route("v1/products")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try { 
          _context.Products.Add(product);
          await _context.SaveChangesAsync();

            return Ok(product);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível criar a categoria." });
        }
        }

        //uptade an existing category
        [Route("v1/categories/{id:int}")]
        [HttpPut]
        public async Task<ActionResult<Category>> PutCategory(int id, [FromBody]Category category)
        {
        if (id != category.Id)
        {
            return NotFound(new { message = "Categoria não encontrada" });
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try { 
           _context.Entry<Category>(category).State = EntityState.Modified;
           _context.SaveChanges();

            return Ok(category);
        }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Categoria já atualizada." });
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível atualizar a categoria." });
        }
        }

        //update an existing product
        [Route("v1/products/{id:int}")]
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
            _context.SaveChanges();

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

        //delete a category in database
        [Route("v1/categories")]
        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        
        if (category == null)
        {
            return NotFound(new { message = "Categoria não encontrada" });
        }
        try
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível remover a categoria" });
        }
    }

        //delete a product in database
        [Route("v1/products")]
        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.ID == id);
        if (product == null)
        {
            return NotFound(new { message = "Produto não encontrado" });
        }
        try { 
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

