using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDetails;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public interface IProductImageService
    {
        Task<List<ResultProductmageDetailDto>> GellAllProductDto();
        Task CreateProductImageAsync(CreateProductmageDetailDto createProductmageDetailDto);
        Task UpdateProductImageAsync(UpdateProductmageDetailDto updateProductmageDetailDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductmageDetailDto> GetByIdProductImageAsync(string id);
    }
}
