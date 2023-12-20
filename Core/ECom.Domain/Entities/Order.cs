using ECom.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }

    public string OrderCode { get; set; }
    public Basket Basket { get; set; }
    public CompletedOrder CompletedOrder { get; set; }

}
