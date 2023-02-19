using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class User
{
    public decimal Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Middlename { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime Birthdate { get; set; }

    public string Sex { get; set; } = null!;

    public decimal? Roleid { get; set; }

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();

    public virtual ICollection<Login> Logins { get; } = new List<Login>();

    public virtual ICollection<Parent> Parents { get; } = new List<Parent>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
