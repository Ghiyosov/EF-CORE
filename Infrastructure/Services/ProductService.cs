using System.Net;
using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext _data) : IProductService
{
    public async Task<Response<List<Product>>> GetProducts()
    {
        var products = await _data.Products.ToListAsync();
        return new Response<List<Product>>(products.ToList());
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
        var product = await _data.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product == null
            ? new Response<Product>(HttpStatusCode.NotFound, "Group not found")
            : new Response<Product>(product);
    }

    public async Task<Response<string>> AddProduct(ProductDto product)
    {
        await _data.Products.AddAsync(product);
        var res = await _data.SaveChangesAsync();

        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Product not created")
            : new Response<string>("Product created successfully");
    }

    public async Task<Response<string>> UpdateProduct(ProductDto product)
    {
        var productToUpdate = await _data.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        if (productToUpdate == null)
            return new Response<string>(HttpStatusCode.NotFound, "Product not found");
        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Category = product.Category;
        
        var res = await _data.SaveChangesAsync();
        
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Product not updated")
            : new Response<string>("Product updated successfully"); 
        
    }

    public async Task<Response<string>> DeleteProduct(int id)
    {
        var productToDelete = await _data.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (productToDelete == null)
            return new Response<string>(HttpStatusCode.NotFound, "Product not found");
        _data.Products.Remove(productToDelete);
        var res = await _data.SaveChangesAsync();
        
        
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Product not deleted")
            : new Response<string>("Product deleted successfully");
    }
}