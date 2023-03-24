using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Models;

namespace Shop.Domain.Persistance.Repositories.Interfaces
{
    public interface ISalePointRepository
    {
        Task<IEnumerable<SalePoint>> GetAll();
        Task<SalePoint> Get(int id);
        Task<SalePoint> Add(SalePoint entity);
        Task<SalePoint> Update(SalePoint entity);
        Task<SalePoint> Delete(int id);
    }
}
