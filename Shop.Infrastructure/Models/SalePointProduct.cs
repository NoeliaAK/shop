using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Models
{
    public class SalePointProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public SalePoint SalePoint { get; set; }
        public int SalePointId { get; set; }
    }
}
