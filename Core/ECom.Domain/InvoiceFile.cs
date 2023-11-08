using ECom.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class InvoiceFile : BaseFile
    {
        //[Precision(14, 2)]
        public decimal Price { get; set; }
    }
}
