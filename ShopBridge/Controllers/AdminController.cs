using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        ecommerceshopbridgeContext _context;
        public AdminController(ecommerceshopbridgeContext context)
        {
            _context = context;

        }
        [HttpPost("AdminLogin")]
        public IActionResult Login(Admintbl admin)
        {
            var login = _context.Admintbl.Where(t => t.AdminId == admin.AdminId && t.Password == admin.Password).FirstOrDefault();
            if (login != null)
            {
                return Ok();
            }
            else
                return Unauthorized();

        }
    }
}
