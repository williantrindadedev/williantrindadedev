using System.Linq.Expressions;
using WTM.CarManager.Business.Domains.Models;

namespace WTM.CarManager.Business.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<IEnumerable<Brand>> GetByFilter(Expression<Func<Brand,bool>> expression);
        Task<Brand> GetById(Guid id);
        Task<bool> Add(Brand brand);
        Task<bool> Update(Brand brand);
        
    }
}
