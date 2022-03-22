using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ecommerceshopbridgeContext _context;
        public CategoryController(ecommerceshopbridgeContext context)
        {
            this._context = context;

        }

        [HttpGet("GetallCategories")]
        public async Task<IActionResult> getallcategories()
        {
            return Ok(await _context.Categorytbl.ToListAsync());
        }

        [HttpGet("CategoryId/{id}")]
        public async Task<IActionResult> getcategorybyid(int? id)
        {
            try
            {
                if (id != null)
                {   
                        Categorytbl product = await _context.Categorytbl.FindAsync(id);
                     return Ok(product);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch
            {
                return NoContent();
            }
            
            
        }

        [HttpPost("AddCategory")]
        public IActionResult createcategory(Categorytbl category)
        {
            var cat= _context.Categorytbl.Where(t => t.CategoryName.ToUpper() == category.CategoryName.ToUpper()).FirstOrDefault();
            if (cat == null) 
            { 
            _context.Categorytbl.Add(category);
            _context.SaveChanges();
            return Ok();
            }
            else
                return BadRequest("Category is already there in database ");
        }

        [HttpPut("UpdateCategory/{id}")]
        public IActionResult updatecategory(int? id, Categorytbl category)
        {
            try
            {
            if (id != null)
            {
                _context.Categorytbl.Update(category);
                _context.SaveChanges();
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult deletecategory(int? id)
        {
            try 
            { 
            if (id != null)
            {
                Categorytbl category = _context.Categorytbl.Find(id);
                _context.Categorytbl.Remove(category);
                _context.SaveChanges();
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
