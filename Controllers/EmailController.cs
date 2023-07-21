using ITsena_back.Data;
using ITsena_back.Models;
using ITsena_back.Repositories;
using ITsena_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITsena_back.Controllers;

[ApiController]
[Route("/Email")]
public class EmailController: ControllerBase
{
    private readonly IEmailSender _emailSender;
    public EmailController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("SendEmail")]
    public async Task<IActionResult> Index(string email, string subject, string message)
    {
        try {
        await _emailSender.SendEmailAsync(email, subject, message);
        return Ok("mail has been sent successfully");
        } catch(Exception)
        {
            throw;
        }
    }
}
