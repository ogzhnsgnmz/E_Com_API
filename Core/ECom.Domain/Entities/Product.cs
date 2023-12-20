using ECom.Domain.Entities.Common;
using ECom.Domain.Entities.Identity;

namespace ECom.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}
