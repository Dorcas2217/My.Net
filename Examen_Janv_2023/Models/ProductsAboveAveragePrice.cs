﻿using System;
using System.Collections.Generic;

namespace Examen_Janv_2023.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
