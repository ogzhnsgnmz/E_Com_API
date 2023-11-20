using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
