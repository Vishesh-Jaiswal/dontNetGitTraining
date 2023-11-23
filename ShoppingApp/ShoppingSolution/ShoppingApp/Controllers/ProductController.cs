using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Exceptions;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using System.Net.Mime;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(IProductService productService,ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        //[Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.GetProducts();
                _logger.LogInformation("Product Listed");
                return Ok(result);
            }
            catch (NoProductsAvailableException e)
            {
                _logger.LogError("No product listed");
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(Product product)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.Add(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
