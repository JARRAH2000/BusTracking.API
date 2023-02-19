using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Studentstatus
{
    public decimal Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
