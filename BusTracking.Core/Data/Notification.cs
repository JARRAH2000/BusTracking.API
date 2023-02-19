using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Notification
{
    public decimal Id { get; set; }

    public DateTime Sendtime { get; set; }

    public string? Message { get; set; }

    public decimal? Studentid { get; set; }

    public decimal? Tripid { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Trip? Trip { get; set; }
}
