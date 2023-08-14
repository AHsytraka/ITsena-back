namespace ITsena_back;

public interface IProductRepository
{
    public Product NewProduct(Product product);
    public List<Product> GetProducts(Guid guid);

    public Task<Product> DeleteProduct(Guid productId);
}
