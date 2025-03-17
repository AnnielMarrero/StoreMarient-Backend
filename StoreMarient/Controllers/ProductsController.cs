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
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(StoreContext context, IMapper mapper, IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _context.Products
                .Include(_ => _.Category)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        /// <summary>
        /// Actualizar las existencias de productos con la nueva cantidad
        /// </summary>
        /// <param name="updateStockItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateStock([FromBody]  List<UpdateStockItemDto> updateStockItemDto)
        {
            if (updateStockItemDto == null || updateStockItemDto.Count == 0)
            {
                return BadRequest("No stocks provided.");
            }
            await _productService.UpdateStock(updateStockItemDto);
            return Ok("Las existencias fueron actualizadas");
        }
        
    }
}
