using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Absence
{
    public decimal Id { get; set; }

    public DateTime? Checkingtime { get; set; }

    public decimal? Teacherid { get; set; }

    public decimal? Studentid { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
