using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.User.Create;

public class CreateUserUseCase
{
    public CreateUserResponse Execute(CreateUserRequest request)
    {
        Validate(request);

        var response = new CreateUserResponse
        {
            Message = "User created successfully.",
            StatusCode = 200
        };

        return response;
    }

    private void Validate(CreateUserRequest request)
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ArgumentException(string.Join("; ", errors));
        }
    }
}
