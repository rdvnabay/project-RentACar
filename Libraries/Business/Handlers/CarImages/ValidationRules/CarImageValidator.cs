using Business.Handlers.Brands.Commands;
using FluentValidation;

namespace Business.Handlers.CarImages.ValidationRules
{
    public class CreateCarImageValidator:AbstractValidator<CreateCarImageCommand>
    {
        public CreateCarImageValidator()
        {
         
        }
    }

    public class UpdateCarImageValidator:AbstractValidator<UpdateCarImageCommand>
    {
        public UpdateCarImageValidator()
        {

        }
    }

}
