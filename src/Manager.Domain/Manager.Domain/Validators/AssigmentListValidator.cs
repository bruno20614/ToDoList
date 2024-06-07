using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class AssignmentListValidator : AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.UserId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}