using ITsena_back.Models;

namespace ITsena_back.Repositories;

public interface ICartRepository
{
    public Task<Cart> AddToCart(Cart cart);
    public List<Cart> GetCarts(Guid userId, Guid productId);
    public Task<Cart> RemoveFromCart(Guid userId, Guid productId);
}
