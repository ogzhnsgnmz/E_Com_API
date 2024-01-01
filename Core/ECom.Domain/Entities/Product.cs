using ECom.Domain.Entities.Common;
using ECom.Domain.Entities.Identity;
using System;
using System.Drawing;

namespace ECom.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
    public Guid SizeId { get; set; }
    public Size Size { get; set; }

    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}
