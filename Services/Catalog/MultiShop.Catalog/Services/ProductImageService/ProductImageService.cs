using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDetails; // DTO'lar ProductImage içindir
using MultiShop.Catalog.Entities;              // Entity: ProductImage
using MultiShop.Catalog.Settings;              // Veritabanı ayarları

namespace MultiShop.Catalog.Services.ProductImageService
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;  // Koleksiyon ismi doğru tanımlandı
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            // MongoDB bağlantısı kur
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            // ProductImage koleksiyonunu al
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);

            // AutoMapper bağlantısı
            _mapper = mapper;
        }

        // ✅ Yeni ürün görseli ekleme
        public async Task CreateProductImageAsync(CreateProductmageDetailDto createProductImageDto)
        {
            var productImageEntity = _mapper.Map<ProductImage>(createProductImageDto);

            await _productImageCollection.InsertOneAsync(productImageEntity);
        }

        // ✅ ID'ye göre ürün görseli silme
        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(pi => pi.PublicImagesID == id);
        }

        public async Task<List<ResultProductmageDetailDto>> GellAllProductDto()
        {
            var productImages = await _productImageCollection.Find(pi => true).ToListAsync();

            return _mapper.Map<List<ResultProductmageDetailDto>>(productImages);
        }


        // ✅ ID'ye göre ürün görselini getirme
        public async Task<GetByIdProductmageDetailDto> GetByIdProductImageAsync(string id)
        {
            var productImage = await _productImageCollection
                .Find(pi => pi.PublicImagesID == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductmageDetailDto>(productImage);
        }

        // ✅ Ürün görselini güncelleme
        public async Task UpdateProductImageAsync(UpdateProductmageDetailDto updateProductImageDto)
        {
            var updatedProductImage = _mapper.Map<ProductImage>(updateProductImageDto);

            await _productImageCollection.FindOneAndReplaceAsync(
                pi => pi.PublicImagesID == updateProductImageDto.PublicImagesID,
                updatedProductImage
            );
        }
    }
}
