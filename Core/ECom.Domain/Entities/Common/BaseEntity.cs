﻿namespace ECom.Domain.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    virtual public DateTime UpdatedDate { get; set; }
}
