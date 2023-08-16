using System.Net;
using ITsena_back.Models;
using ITsena_back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITsena_back.Controllers;

[ApiController]
[Route("/Product")]
public class ProductController: ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository; 
    public ProductController(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    [HttpPost("NewProduct")]
    public IActionResult NewProduct(Product dto)
    {
        var user = _userRepository.GetUserById(dto.UserId);
        if (user == null)
        {
            return BadRequest();
        }
        
        Product product = dto;

        var newProduct = _productRepository.NewProduct(product);
        return Created("Created product successfully", newProduct);
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts(Guid guid)
    {
        var products = _productRepository.GetProducts(guid);
        return Ok(products);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try {
            await _productRepository.DeleteProduct(productId);
            return Ok("Deleted product successfully");
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
        {
            //Handle badRequest
            return BadRequest(ex.Message);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            //Handle notFound
            return NotFound(ex.Message);
        }
        catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            //Handle Unauthorized
            return Unauthorized(ex.Message);
        }
    }
}
