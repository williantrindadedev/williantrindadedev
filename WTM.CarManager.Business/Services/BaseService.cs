using FluentValidation;
using WTM.CarManager.Business.Domains.Models;

namespace WTM.CarManager.Business.Services
{
    public abstract class BaseService
    {
        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validationResult = validation.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException();
            }
            return true;
        }

    }
}
