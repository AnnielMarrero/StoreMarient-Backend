using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreMarient.Data;
using StoreMarient.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using StoreMarient.Dtos;
using AutoMapper;
using StoreMarient.Services;

namespace StoreMarient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicasController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        private readonly IMicaService _micaService;
        public MicasController(StoreContext context, IMapper mapper, IMicaService micaService)
        {
            _context = context;
            _mapper = mapper;
            _micaService = micaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicaDto>>> GetAll()
        {
            var micas = await _context.Micas
                .Include(_ => _.PhoneType)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<MicaDto>>(micas));

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
            await _micaService.UpdateStock(updateStockItemDto);
            return Ok("Las existencias fueron actualizadas");
        }
    }
}
