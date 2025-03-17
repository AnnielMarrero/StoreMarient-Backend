using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreMarient.Data;
using StoreMarient.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StoreMarient.Services.Base;
using StoreMarient.Dtos;

namespace StoreMarient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public CoversController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoverDto>>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CoverDto>>(await _context.Covers.Include(_ => _.PhoneType).ToListAsync()));

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
