using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Tripstudent
{
    public decimal Id { get; set; }

    public TimeSpan Arrivaltime { get; set; }

    public decimal? Studentid { get; set; }

    public decimal? Tripid { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Trip? Trip { get; set; }
}
