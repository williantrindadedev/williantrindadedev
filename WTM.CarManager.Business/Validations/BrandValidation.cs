using FluentValidation;
using WTM.CarManager.Business.Domains.Models;

namespace WTM.CarManager.Business.Validations
{
    public class BrandValidation : AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractéres")
                .WithName("Nome");

        }
    }
}
