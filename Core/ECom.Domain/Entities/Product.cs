using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
    public ICollection<ProductAttribute> Attributes { get; set; }
}
