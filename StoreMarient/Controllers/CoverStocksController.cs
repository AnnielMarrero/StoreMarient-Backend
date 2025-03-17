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
    public class CoverStocksController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        private readonly ICoverStockService _coverStockService;

        public CoverStocksController(StoreContext context, IMapper mapper, ICoverStockService coverStockService)
        {
            _context = context;
            _mapper = mapper;
            _coverStockService = coverStockService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoverStockDto>>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CoverStockDto>>(await _coverStockService.GetAllAsync()));

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
            await _coverStockService.UpdateStock(updateStockItemDto);
            return Ok("Las existencias fueron actualizadas");
        }
    }
}
