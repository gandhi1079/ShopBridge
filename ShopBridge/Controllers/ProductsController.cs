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
    public class ProductsController : Controller
    {
        ecommerceshopbridgeContext _context;
        public ProductsController(ecommerceshopbridgeContext context)
        {
            this._context = context;

        }
        [HttpGet("ProductList")]
        public async Task<IActionResult> getallproducts()
        {   
             return Ok( await _context.Producttbl.ToListAsync());
        }
        
        [HttpGet("LessQuantityAlert")]
        public async Task<IActionResult> quanitityleassthan5()
        {
            return Ok(await _context.Producttbl.Where(t => t.Quanity <= 5).ToListAsync());
        }

        [HttpGet("GetByProductId/{id}")]
        public async Task<IActionResult> getbyproductid(int? id)
        {
            try { 
            var product = await _context.Producttbl.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            else
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }


        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> PostProduct(Producttbl product)
        {

            _context.Producttbl.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //[HttpPost("Add")]
        //public IActionResult create(Producttbl p)
        //{
        //    db.Producttbl.Add(p);
        //    db.SaveChanges();
        //    return Ok();
        //}
        [HttpPut("UpdatebyProductId/{id}")]
        public async Task<IActionResult> update(int? id, Producttbl product)
        {
            try 
            { 
            if (id != null)
            {
                _context.Producttbl.Update(product);
               await _context.SaveChangesAsync();
                return Ok(product);
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

        [HttpDelete("DeletebyProductId/{id}")]
        public async Task<IActionResult> delete(int? id)
        {
            try 
            { 
            if (id != null)
            {
                var product = await _context.Producttbl.FindAsync(id);
                _context.Producttbl.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
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
        [HttpGet("search/{word}")]
        public async Task<IActionResult> searchproduct(string word)
        {
           
                if (string.IsNullOrEmpty(word))
                {
                    return Ok(await _context.Producttbl.ToListAsync());
                }
                else
                    return Ok(await _context.Producttbl.Where(e => e.ProductName.ToUpper().Contains(word.ToUpper())|| e.ProductDesc.ToUpper().Contains(word.ToUpper())).ToListAsync());
        
        }
    }
}
