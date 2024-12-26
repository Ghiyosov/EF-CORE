using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interface;

public interface IProductService
{
    public Task<Response<List<Product>>> GetProducts();
    public Task<Response<Product>> GetProductById(int id);
    public Task<Response<string>> AddProduct(ProductDto product);
    public Task<Response<string>> UpdateProduct(ProductDto product);
    public Task<Response<string>> DeleteProduct(int id);
}