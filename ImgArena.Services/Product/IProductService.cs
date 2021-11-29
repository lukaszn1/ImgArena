using ImgArena.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImgArena.Services.Product
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductAsync(int productId);
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
    }
}
