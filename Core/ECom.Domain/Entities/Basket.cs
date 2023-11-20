using ECom.Domain.Entities.Common;
using ECom.Domain.Entities.Identity;

namespace ECom.Domain.Entities;

public class Basket : BaseEntity
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public Order Order { get; set; }

    public ICollection<BasketItem> BasketItems { get; set; }

}
