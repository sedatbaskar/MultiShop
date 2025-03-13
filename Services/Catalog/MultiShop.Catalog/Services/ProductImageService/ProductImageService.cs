using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDto; 
using MultiShop.Catalog.Entities;              
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public class ProductImageService
    {

        private readonly IMongoCollection<ProductImage> _productImage;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImage = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImage.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImage.DeleteOneAsync(x => x.PublicImagesID == id);
        }
        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImage.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productImage.Find(x => x.PublicImagesID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);

        }
        public async Task UpdateProductImageAsync(string id, UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImage.ReplaceOneAsync(x => x.PublicImagesID == id, value);
        }
    }
    }
