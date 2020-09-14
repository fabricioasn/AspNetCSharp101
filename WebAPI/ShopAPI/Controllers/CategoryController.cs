using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopAPI.Models;
using ShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

// https://localhost:5001/v1/categories local
// https://myapp.azurewebsites.net azure

namespace Shop.Controllers
{

    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly DataContextShopDTO _context;
        public CategoryController([FromServices] DataContextShopDTO context)
        {
            _context = context;
        }

        //read categories as a list enumerable      
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        //get a category by ID    
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var categories = await _context.Categories.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(categories);
        }


        //create a new category    
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> PostCategory(
            [FromBody] Category category,
            [FromServices] DataContextShopDTO dataContext)
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

        //uptade an existing category    
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> PutCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Entry<Category>(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Categoria já atualizada." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }
        }

        //delete a category in database    
        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "manager")] // only the manager has permission to cascade delete a category
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


    }
}
