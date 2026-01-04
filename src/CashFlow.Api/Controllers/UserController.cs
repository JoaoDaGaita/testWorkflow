using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        try
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new { Error = "Name and Email are required." });
            }

            // Aqui você pode adicionar lógica de negócio para salvar o usuário
            var response = new CreateUserResponse
            {
                Message = "User created successfully.",
                StatusCode = 200
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
