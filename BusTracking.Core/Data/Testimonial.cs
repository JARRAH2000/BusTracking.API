using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Testimonial
{
    public decimal Id { get; set; }

    public string Message { get; set; } = null!;

	public string? Published { get; set; }

	public decimal? Parentid { get; set; }
}
