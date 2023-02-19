using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Employeestatus
{
    public decimal Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Bus> Buses { get; } = new List<Bus>();

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
