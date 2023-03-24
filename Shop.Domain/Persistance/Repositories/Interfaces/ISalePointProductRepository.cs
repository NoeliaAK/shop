using Shop.Domain.Models;
using Shop.Infrastructure.Models;

namespace Shop.Domain.Persistance.Repositories.Interfaces
{
    public interface ISalePointProductRepository
    {
        Task UpdateSalePointProduct(SalePointProductDTO entity);
        List<SalePointProductDTO> GetSalePointProductBySalePointId(int salePointId);
    }
}
