using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WTM.CarManager.Business.Domains.Models;
using WTM.CarManager.Business.Interfaces;
using WTM.CarManager.Infrasctructure.Contexts;

namespace WTM.CarManager.Infrasctructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetByFilter(Expression<Func<Brand, bool>> expression)
        {
            return await _context.Brands.Where(expression).ToListAsync();
        }

        public async Task<Brand> GetById(Guid id)
        {
            return (await _context.Brands.FirstOrDefaultAsync(x => x.Id == id)) ?? default!;
        }

        public async Task<bool> Update(Brand brand)
        {
            _context.Brands.Update(brand);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Add(Brand brand)
        {
            _context.Brands.Add(brand);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
