using ITsena_back.Data;
using ITsena_back.Models;

namespace ITsena_back.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product NewProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return product;
    }

    public List<Product> GetProducts(Guid guid)
    {
        var products = _dbContext.Products.Where(p => p.UserId == guid).ToList();
        return products;
    }

    public async Task<Product> DeleteProduct(Guid productId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
        return product;
    }
}
