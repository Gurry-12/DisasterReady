using DisasterReady.Application.DTOs;
using FluentValidation;

namespace DisasterReady.Application.Validators
{
    public class CreateAlertDtoValidator : AbstractValidator<CreateAlertDto>
    {
        public CreateAlertDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.DisasterTypeId)
                .GreaterThan(0);

            RuleFor(x => x.ExpiresAt)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.ExpiresAt.HasValue);
        }
    }

    public class UpdateAlertDtoValidator : AbstractValidator<UpdateAlertDto>
    {
        public UpdateAlertDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.DisasterTypeId)
                .GreaterThan(0);

            RuleFor(x => x.ExpiresAt)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.ExpiresAt.HasValue);
        }
    }
} 