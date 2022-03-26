using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Araç adı giriniz");
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Fiyat giriniz");
           // RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Araç fiyatı 0'dan küçük olamaz!");
        }
    }
}
