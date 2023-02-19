using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Role
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
