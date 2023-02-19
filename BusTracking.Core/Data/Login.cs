using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Login
{
    public decimal Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? Userid { get; set; }

    public virtual User? User { get; set; }
}
