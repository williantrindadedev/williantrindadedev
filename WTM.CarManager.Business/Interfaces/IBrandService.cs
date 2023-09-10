using WTM.CarManager.Business.Domains.Models;

namespace WTM.CarManager.Business.Interfaces
{
    public interface IBrandService
    {
        Task<bool> Add(Brand brand);
        Task<bool> Update(Brand brand);

    }
}
