using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("Api/[controller]")]
public class ProductController(IProductService _product) : ControllerBase
{
    [HttpGet("GetProducts")]
    public async Task<Response<List<Product>>> GetProducts()
        => await _product.GetProducts();

    [HttpGet("GetProduct/{id}")]
    public async Task<Response<Product>> GetProduct(int id)
        => await _product.GetProductById(id);
    
    [HttpPost("AddProduct")]
    public async Task<Response<string>> AddProduct(ProductDto product)
        => await _product.AddProduct(product);
    
    [HttpPut("UpdateProduct")]
    public async Task<Response<string>> UpdateProduct(ProductDto product)
        => await _product.UpdateProduct(product);
    
    [HttpDelete("DeleteProduct/{id}")]
    public async Task<Response<string>> DeleteProduct(int id)
        => await _product.DeleteProduct(id);
}