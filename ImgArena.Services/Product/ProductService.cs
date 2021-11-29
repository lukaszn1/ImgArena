using AutoMapper;
using ImgArena.Models.DTOs;
using ImgArena.Repositories.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImgArena.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
        {
            var result =  _productRepository.Insert(_mapper.Map<DataStorage.Product.Product>(productDto));

            return await Task.FromResult(_mapper.Map<ProductDto>(result));
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            var result = _mapper.Map<ProductDto>(_productRepository.GetById(productId));

            return await Task.FromResult(result);
        }

        public async Task<IList<ProductDto>> GetProductsAsync()
        {
            var result = _productRepository.GetAll()
                .Select(x => _mapper.Map<ProductDto>(x))
                .ToList();

            return await Task.FromResult<IList<ProductDto>>(result);
        }
    }
}