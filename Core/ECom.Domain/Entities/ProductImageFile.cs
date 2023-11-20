using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class ProductImageFile : BaseFile
{
    public bool Showcase { get; set; }
    public ICollection<Product> Products { get; set; }

    //public Guid ProductId { get; set; }
    //public Product Product { get; set; }
}
