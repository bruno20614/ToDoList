using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(255);

        RuleFor(c => c.Deadline)
            .GreaterThan(DateTime.Now);
        
        RuleFor(c => c.UserId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}