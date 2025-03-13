using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailsService
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailsCollection;
        private readonly IMapper _mapper;

        public ProductDetailsService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailsCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        // ✅ Ürün Detayı Ekleme
        public async Task CreateProductDetailAsync(CreateProductDetailsDto createProductDetailsDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailsDto);
            await _productDetailsCollection.InsertOneAsync(productDetail);
        }

        // ✅ Ürün Detayı Silme
        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailsCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        // ✅ Tüm Ürün Detaylarını Getir
        public async Task<List<ResultProductDetailsDto>> GellAllProductDetailasync()
        {
            var details = await _productDetailsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailsDto>>(details);
        }

        // ✅ Belirli Bir Ürün Detayını Getir
        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var detail = await _productDetailsCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(detail);
        }

        // ✅ Ürün Detayı Güncelleme
        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var updatedDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailsCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, updatedDetail);
        }
    }
}
