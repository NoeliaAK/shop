using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models
{
    public class SalePointProductDTO
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SalePointId { get; set; }
        public bool Selected { get; set; }
    }
}
