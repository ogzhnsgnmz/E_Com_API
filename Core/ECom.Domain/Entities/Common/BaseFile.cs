﻿namespace ECom.Domain.Entities.Common;

public class BaseFile : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
}
