using Business.Handlers.Brands.Commands;
using FluentValidation;

namespace Business.Handlers.Cars.ValidationRules
{
    public class CreateCarValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ModelYear).NotEmpty();
        }
    }

    public class UpdateCarValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarValidator()
        {
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ModelYear).NotEmpty();
        }
    }
}
