using Domein.Entities;

namespace Domein.DTOs;

public class ProductDto : Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}