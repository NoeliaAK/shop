using Shop.Infrastructure;
using Shop.Domain.Persistance.Repositories.Interfaces;
using Shop.Infrastructure.Models;
using Shop.Domain.Models;

namespace Shop.Domain.Persistance.Repositories
{
    public class SalePointProductRepository : ISalePointProductRepository
    {
        protected readonly AppDbContext _context;
        public SalePointProductRepository(AppDbContext context) { _context = context; }

        //GetSalePointProductBySalePointId brings the relation between the Sale Point object and the Product. 
        public List<SalePointProductDTO> GetSalePointProductBySalePointId(int salePointId)
        {
            var query = _context.Products.SelectMany
            (
                p => _context.SalePointProducts.Where(spp => p.Id == spp.ProductId && salePointId == spp.SalePointId).DefaultIfEmpty(),
                (p, spp) => new SalePointProductDTO
                {
                    Id = spp.Id,
                    ProductId = p.Id,
                    ProductName = p.Name,
                    SalePointId = salePointId
                }
            );

            return query.ToList();
        }
        
        public async Task UpdateSalePointProduct(SalePointProductDTO entity)
        {
            var salePointProd = _context.SalePointProducts.Where(x => x.ProductId == entity.ProductId &&
            x.SalePointId == entity.SalePointId).FirstOrDefault();

            if (salePointProd != null && !entity.Selected)
            {
                _context.Set<SalePointProduct>().Remove(salePointProd);
            }
            else
            {
                _context.Set<SalePointProduct>().Add(new SalePointProduct
                {
                    ProductId = entity.ProductId,
                    SalePointId = entity.SalePointId                    
                });

            }
            await _context.SaveChangesAsync();
        }
    }
}
