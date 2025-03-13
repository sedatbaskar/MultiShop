using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductDetailsService
{
    public interface IProductDetailsService
    {
        Task<List<ResultProductDetailsDto>> GellAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailsDto  createProductDetailsDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto  updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);

    }
}
