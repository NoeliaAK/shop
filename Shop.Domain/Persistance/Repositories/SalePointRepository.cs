using Shop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Persistance.Repositories.Interfaces;
using Shop.Infrastructure.Models;

namespace Shop.Domain.Persistance.Repositories
{
    public class SalePointRepository : ISalePointRepository
    {
        protected readonly AppDbContext _context;
        public SalePointRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<SalePoint>> GetAll()
        {
            return await _context.SalePoints.ToListAsync();
        }

        public async Task<SalePoint> Get(int id)
        {
            return await _context.SalePoints.FindAsync(id);
        }

        public async Task<SalePoint> Add(SalePoint entity)
        {
            _context.Set<SalePoint>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SalePoint> Update(SalePoint entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SalePoint> Delete(int id)
        {
            var entity = await _context.Set<SalePoint>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<SalePoint>().Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }

            return null;
        }
    }
}
