using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Review
{
    public decimal Id { get; set; }

    public decimal? Stars { get; set; }

    public decimal? Parentid { get; set; }
}
