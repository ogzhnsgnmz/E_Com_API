﻿using ECom.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Basket Basket { get; set; }

    public List<Product_Order> Products_Orders { get; set; }
}
