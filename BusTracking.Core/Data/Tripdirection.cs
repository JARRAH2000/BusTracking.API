using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Tripdirection
{
    public decimal Id { get; set; }

    public string Direction { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
