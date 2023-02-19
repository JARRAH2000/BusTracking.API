using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Trip
{
    public decimal Id { get; set; }

    public decimal? Teacherid { get; set; }

    public decimal? Busid { get; set; }

    public decimal? Driverid { get; set; }

    public DateTime Tripdate { get; set; }

    public TimeSpan Starttime { get; set; }

    public TimeSpan Endtime { get; set; }

    public string Longitude { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public decimal? Directionid { get; set; }

    public virtual Bus? Bus { get; set; }

    public virtual Tripdirection? Direction { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Tripstudent> Tripstudents { get; } = new List<Tripstudent>();
}
