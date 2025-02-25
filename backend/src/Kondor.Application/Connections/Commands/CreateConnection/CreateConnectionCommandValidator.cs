using FluentValidation;

namespace Kondor.Application.Connections.Commands.CreateConnection;

public class CreateConnectionCommandValidator : AbstractValidator<CreateConnectionCommand>
{
    public CreateConnectionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.Host)
            .NotEmpty().WithMessage("Host is required")
            .MaximumLength(255).WithMessage("Host cannot exceed 255 characters");

        RuleFor(x => x.Port)
            .GreaterThan(0).WithMessage("Port must be greater than 0")
            .LessThanOrEqualTo(65535).WithMessage("Port cannot exceed 65535");

        RuleFor(x => x.Database)
            .NotEmpty().WithMessage("Database is required")
            .MaximumLength(100).WithMessage("Database cannot exceed 100 characters");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .MaximumLength(50).WithMessage("Username cannot exceed 50 characters");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters");

        RuleFor(x => x.ConnectionString)
            .NotEmpty().WithMessage("Connection string is required")
            .MaximumLength(500).WithMessage("Connection string cannot exceed 500 characters");
    }
}