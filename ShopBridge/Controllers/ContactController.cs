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
    public class ContactController : Controller
    {
        ecommerceshopbridgeContext _context;

        public ContactController(ecommerceshopbridgeContext context)
        {
            this._context = context;

        }
        [HttpGet("AllMessages")]
        public async Task<IActionResult> getallmeassge()
        {
            return Ok(await _context.Contacttbl.ToListAsync());
        }
        [HttpGet("MessagebyId/{id}")]
        public async Task<IActionResult> getbyid(int? id)
        {
            try
            {
                Contacttbl message = await _context.Contacttbl.FindAsync(id);
                if (message != null)
                    return Ok(message);
                else
                    return BadRequest();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("AddNewMessage")]
        public async Task<IActionResult>createmessage(Contacttbl message)
        {
            _context.Contacttbl.Add(message);
           await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteMessage/{id}")]
        public async Task<IActionResult> deletemessage(int? id)
        {
            try
            { 
            if (id != null)
            {
                Contacttbl message =await _context.Contacttbl.FindAsync(id);
                _context.Contacttbl.Remove(message);
                _context.SaveChanges();
                return Ok(message);
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

    }
}
