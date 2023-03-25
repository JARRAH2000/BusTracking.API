using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Bus
{
    public decimal Id { get; set; }

    public decimal? Capacity { get; set; }

    public string? Vrp { get; set; } = null!;

    public string? Brand { get; set; } = null!;

    public string? Model { get; set; } = null!;

    public DateTime? Licensedate { get; set; }

    public string? Image { get; set; }

    public decimal? Statusid { get; set; }

    public decimal? Currenttrip { get; set; }

    public virtual Employeestatus? Status { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
