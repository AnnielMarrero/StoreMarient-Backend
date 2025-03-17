using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreMarient.Data;
using StoreMarient.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Services;

namespace StoreMarient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        private readonly IPhoneService _phoneService;

        public PhonesController(StoreContext context, IMapper mapper, IPhoneService phoneService)
        {
            _context = context;
            _mapper = mapper;
            _phoneService = phoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneDto>>> GetAll()
        {
            var phones = await _context.Phones
                .Include(_ => _.Piece)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<PhoneDto>>(phones));
        }
        /// <summary>
        /// Actualizar las existencias de productos con la nueva cantidad
        /// </summary>
        /// <param name="updateStockItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateStock([FromBody] List<UpdateStockItemDto> updateStockItemDto)
        {
            if (updateStockItemDto == null || updateStockItemDto.Count == 0)
            {
                return BadRequest("No stocks provided.");
            }
            await _phoneService.UpdateStock(updateStockItemDto);
            return Ok("Las existencias fueron actualizadas");
        }
    }
}
