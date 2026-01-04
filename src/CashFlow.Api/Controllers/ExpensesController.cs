using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;
using CashFlow.Application.UseCases.Expenses.Register;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);
        return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch
        {
            return StatusCode(500, new { Error = "An unexpected error occurred." });
        }
    }
}
