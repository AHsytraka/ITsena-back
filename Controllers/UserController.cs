using ITsena_back.Models;
using ITsena_back.Repositories;
using ITsena_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITsena_back.Controllers;

[ApiController]
[Route("/User")]
public class UserController: ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository, JwtService jwtService)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    [HttpPost("Signup")]
    public async Task<IActionResult> Signup(User dto)
    {
        User user = new() {
            Username = dto.Username,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        var signed = await _userRepository.SignupUser(user);
        return Created("signed up successfully", signed);
    }

    [HttpPost("Signin")]
    public IActionResult Signin(string email,string pwd)
    {
        var user = _userRepository.GetUserByEmail(email);
        if(user == null) 
            return BadRequest(new {message = "Invalide or wrong Email"});
        if(!BCrypt.Net.BCrypt.Verify(pwd,user.Password))
            return BadRequest(new {message = "Wrong password"});
        
        return Ok(user);
    }
} 
