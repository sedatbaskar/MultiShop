using MultiShop.Discount.Dto;

namespace MultiShop.Discount.Service
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCuoponAsync();
        Task CreateCuoponAsync(CreateCouponDto createCouponDto);
        Task UpdateCuoponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCuopnAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);

    }
}
