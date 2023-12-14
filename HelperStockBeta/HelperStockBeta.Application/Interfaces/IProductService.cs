using HelperStockBeta.Application.DTOs;

namespace HelperStockBeta.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(int id, ProductDTO productDTO);
        Task RemoveProduct(int id);
    }
}
