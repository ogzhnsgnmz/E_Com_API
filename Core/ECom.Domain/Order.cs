using ECom.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Product_Order> Products_Orders { get; set; }

        public Basket Basket { get; set; }
    }
}
