using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Contact
{
    public decimal Id { get; set; }

    public string Email { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Name { get; set; } = null!;
    public DateTime Sendtime { get; set; }
}
