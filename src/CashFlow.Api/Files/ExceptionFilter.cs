namespace CashFlow.Api.Files;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Exception is ErrorOnValidationException
            ? HandleProjectException(context)
            : ThrowUnknowException(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        context.Result = new BadRequestObjectResult(new { Error = context.Exception.Message });
        context.ExceptionHandled = true;
    }
    private void ThrowUnknowException(ExceptionContext context)
    {
        var errorResponse = ResponseErrorJson("Unknown error", "An unexpected error occurred.");
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new JsonResult(errorResponse);
    }
}