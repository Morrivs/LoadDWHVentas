﻿using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.Northwind;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}