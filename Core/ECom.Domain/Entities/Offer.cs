using ECom.Domain.Entities.Common;
using ECom.Domain.Entities.Identity;

namespace ECom.Domain.Entities;

public class Offer : BaseEntity
{
    //[Precision(14, 2)]
    public decimal OfferPrice { get; set; }
    public bool IsAccepted { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
