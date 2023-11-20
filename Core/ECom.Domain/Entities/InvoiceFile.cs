using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class InvoiceFile : BaseFile
{
    //[Precision(14, 2)]
    public decimal Price { get; set; }
}
