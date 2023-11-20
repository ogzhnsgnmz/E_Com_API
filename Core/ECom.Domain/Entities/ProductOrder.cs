using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Product_Order : BaseEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
