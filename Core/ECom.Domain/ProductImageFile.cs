using ECom.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class ProductImageFile : BaseFile
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
