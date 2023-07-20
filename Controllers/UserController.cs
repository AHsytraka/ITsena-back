using ITsena_back.Data;
using ITsena_back.Models;
using ITsena_back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITsena_back.Controllers;

[ApiController]
[Route("/Controller")]
public class UserController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IUserRepository _userRepository;
    public UserController(AppDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
    }

    [HttpPost("Signup")]
    public async Task<IActionResult> Signup(User dto)
    {
        User user = new User {
            Name = dto.Name,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        var signed = await _userRepository.SignupUser(user);
        return Created("signed up successfully", signed);
    }
}