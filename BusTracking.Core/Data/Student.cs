using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data;

public partial class Student
{
    public decimal Id { get; set; }

    public string? Name { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Sex { get; set; } = null!;

    public string? Longitude { get; set; } = null!;

    public string? Latitude { get; set; } = null!;

    public string? Absencenotify { get; set; } = null!;

    public string? Busnotify { get; set; } = null!;

    public string? Inhomenotify { get; set; } = null!;

    public string? Inschoolnotify { get; set; } = null!;

    public string? Tohomenotify { get; set; } = null!;

    public string? Toschoolnotify { get; set; } = null!;

    public decimal? Paretnid { get; set; }

    public decimal? Statusid { get; set; }

    public virtual ICollection<Absence> Absences { get; } = new List<Absence>();

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual Parent? Paretn { get; set; }

    public virtual Studentstatus? Status { get; set; }

    public virtual ICollection<Tripstudent> Tripstudents { get; } = new List<Tripstudent>();
}
