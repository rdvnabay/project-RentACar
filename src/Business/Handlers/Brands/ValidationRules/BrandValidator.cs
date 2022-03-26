using Business.Handlers.Brands.Commands;
using FluentValidation;

namespace Business.Handlers.Brands.ValidationRules
{
    public class CreateBrandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
