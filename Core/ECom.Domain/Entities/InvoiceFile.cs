using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class InvoiceFile : File
{
    //[Precision(14, 2)]
    public decimal Price { get; set; }
}
