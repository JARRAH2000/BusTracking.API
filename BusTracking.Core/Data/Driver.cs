using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Driver
{
    public decimal Id { get; set; }

    public DateTime? Licensedate { get; set; }

    public decimal? Statusid { get; set; }

    public decimal? Userid { get; set; }

    public virtual Employeestatus? Status { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public virtual User? User { get; set; }
}
