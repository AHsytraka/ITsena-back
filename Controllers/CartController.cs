using System.Net;
using ITsena_back.Models;
using ITsena_back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITsena_back.Controllers;

[ApiController]
[Route("/Cart")]
public class CartController:ControllerBase
{
    private readonly ICartRepository _cartRepository;
    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost("/AddToCart")]
    public async Task<IActionResult> AddProductToCart(Cart cart)
    {
        try {
            await _cartRepository.AddToCart(cart);
            return Ok("Added product to cart successfully "+ cart);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
        {
            //Handle badRequest
            return BadRequest(ex.Message);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            //Handle Unauthorized
            return Unauthorized(ex.Message);
        }
    }

    [HttpGet("/GetCarts")]
    public IActionResult GetCart(Guid userId,Guid productId)
    {
        try {
            var cart = _cartRepository.GetCarts(userId, productId);
            return Ok(cart);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
        {
            //Handle badRequest
            return BadRequest(ex.Message);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            //Handle Unauthorized
            return Unauthorized(ex.Message);
        }
    }

    [HttpDelete("/DeleteFromCart")]
    public IActionResult DeleteFromCart(Guid userId,Guid productId)
    {
        try {
            var cart = _cartRepository.RemoveFromCart(userId, productId);
            return Ok(cart);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
        {
            //Handle badRequest
            return BadRequest(ex.Message);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            //Handle Unauthorized
            return Unauthorized(ex.Message);
        }
    }
}