using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreMarient.Data;
using StoreMarient.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace StoreMarient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneTypesController : ControllerBase
    {
        private readonly StoreContext _context;

        public PhoneTypesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneType>>> GetAll()
        {
            return await _context.PhoneTypes.ToListAsync();
        }
        /*
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
        */
    }
}
