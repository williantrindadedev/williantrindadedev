using FluentValidation;
using WTM.CarManager.Business.Enumerators;
using WTM.CarManager.Business.Validations;

namespace WTM.CarManager.Business.Domains.Models
{
    public class Brand : Entity
    {
        public string Name { get; private set; }
        public StatusTypeEnum Status { get; private set; }

        public Brand(string name)
        {
            Name = name;
            IsValid();
        }
        public void IsActive()
        {
            Status = StatusTypeEnum.Active;
        }
        public void IsCancel()
        {
            Status = StatusTypeEnum.Cancel;
        }
        protected override bool IsValid()
        {
            var validation = new BrandValidation().Validate(this);
            if (!validation.IsValid)
            {
                throw new ArgumentException();
            }
            return true;
        }
    }
}
