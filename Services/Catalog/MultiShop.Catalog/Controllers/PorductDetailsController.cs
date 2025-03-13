using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailsService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;

        public PorductDetailsController(IProductDetailsService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _productDetailsService.GellAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = _productDetailsService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailsDto  createProductDetailsDto)
        {
            await _productDetailsService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Product Detail Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailsService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailsService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail Başarıyla Silindi");
        }
    }
}
