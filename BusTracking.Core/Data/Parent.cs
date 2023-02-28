using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Parent
{
    public decimal Id { get; set; }

    public decimal? Userid { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual User? User { get; set; }
}
