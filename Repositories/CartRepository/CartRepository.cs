using ITsena_back.Data;
using ITsena_back.Models;

namespace ITsena_back.Repositories;

public class CartRepository: ICartRepository
{
    private readonly AppDbContext _dbContext;
    public CartRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Cart> AddToCart(Cart cart)
    {
        await _dbContext.AddAsync(cart);
        await _dbContext.SaveChangesAsync();
        return cart;
    }

    public List<Cart> GetCarts(Guid userId, Guid productId)
    {
        var cart = _dbContext.Carts.Where(
            cart => cart.UserId == userId && cart.ProductId == productId).ToList();
        return cart;
    }

    public async Task<Cart> RemoveFromCart(Guid userId, Guid productId)
    {
        var cart = _dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
        _dbContext.Remove(cart);
        await _dbContext.SaveChangesAsync();
        return cart;
    }
}
