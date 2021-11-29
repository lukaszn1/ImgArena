using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImgArena.Models.DTOs;
using ImgArena.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImgArena.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{productId:int}")]
        public async Task<IActionResult> Get(int productId)
        {
            try
            {
                var product = await _productService.GetProductAsync(productId);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); //todo move exception handler to middleware layer/create grobal exception filter
                return StatusCode(500);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetProductsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); //todo move exception handler to middleware layer/create grobal exception filter
                return StatusCode(500);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto newProduct)
        {
            try
            {
                //todo if more complex validation needed => create a validation here and potentialy return BadRequest
                var createdProduct = await _productService.CreateProductAsync(newProduct);

                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); //todo move exception handler to middleware layer/create grobal exception filter
                return StatusCode(500);
            }
        }
    }
}
