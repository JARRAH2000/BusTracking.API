using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusTracking.Core.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employeestatus> Employeestatuses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Studentstatus> Studentstatuses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Tripdirection> Tripdirections { get; set; }

    public virtual DbSet<Tripstudent> Tripstudents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=JOR15_User76;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("JOR15_USER76")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Absence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324503");

            entity.ToTable("ABSENCE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Checkingtime)
                .HasPrecision(6)
                .HasColumnName("CHECKINGTIME");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Teacherid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TEACHERID");

            entity.HasOne(d => d.Student).WithMany(p => p.Absences)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324505");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Absences)
                .HasForeignKey(d => d.Teacherid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324504");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324434");

            entity.ToTable("BUS");

            entity.HasIndex(e => e.Vrp, "SYS_C00324435").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Capacity)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Licensedate)
                .HasColumnType("DATE")
                .HasColumnName("LICENSEDATE");
            entity.Property(e => e.Model)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Vrp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("VRP");

            entity.HasOne(d => d.Status).WithMany(p => p.Buses)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324436");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324424");

            entity.ToTable("DRIVER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Licensedate)
                .HasColumnType("DATE")
                .HasColumnName("LICENSEDATE");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Status).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324425");

            entity.HasOne(d => d.User).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324426");
        });

        modelBuilder.Entity<Employeestatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324398");

            entity.ToTable("EMPLOYEESTATUS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324417");

            entity.ToTable("LOGIN");

            ///add manualy
            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324418");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324518");

            entity.ToTable("NOTIFICATION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Message)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MESSAGE");
            entity.Property(e => e.Sendtime)
                .HasPrecision(6)
                .HasColumnName("SENDTIME");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Tripid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRIPID");

            entity.HasOne(d => d.Student).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324519");

            entity.HasOne(d => d.Trip).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Tripid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324520");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324420");

            entity.ToTable("PARENT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Parents)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324421");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324376");

            entity.ToTable("ROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324498");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Absencenotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ABSENCENOTIFY");
            entity.Property(e => e.Birthdate)
                .HasColumnType("DATE")
                .HasColumnName("BIRTHDATE");
            entity.Property(e => e.Busnotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BUSNOTIFY");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Inhomenotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INHOMENOTIFY");
            entity.Property(e => e.Inschoolnotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INSCHOOLNOTIFY");
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Parentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PARENTID");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEX");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Tohomenotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TOHOMENOTIFY");
            entity.Property(e => e.Toschoolnotify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TOSCHOOLNOTIFY");

            entity.HasOne(d => d.Parent).WithMany(p => p.Students)
                .HasForeignKey(d => d.Parentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324499");

            entity.HasOne(d => d.Status).WithMany(p => p.Students)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324500");
        });

        modelBuilder.Entity<Studentstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324457");

            entity.ToTable("STUDENTSTATUS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324438");

            entity.ToTable("TEACHER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Status).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324440");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324439");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324450");

            entity.ToTable("TRIP");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Busid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("BUSID");
            entity.Property(e => e.Directionid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DIRECTIONID");
            entity.Property(e => e.Driverid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DRIVERID");
            entity.Property(e => e.Endtime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.Starttime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Teacherid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TEACHERID");
            entity.Property(e => e.Tripdate)
                .HasColumnType("DATE")
                .HasColumnName("TRIPDATE");

            entity.HasOne(d => d.Bus).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Busid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324452");

            entity.HasOne(d => d.Direction).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Directionid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324454");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324453");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Teacherid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324451");
        });

        modelBuilder.Entity<Tripdirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324443");

            entity.ToTable("TRIPDIRECTION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DIRECTION");
        });

        modelBuilder.Entity<Tripstudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324555");

            entity.ToTable("TRIPSTUDENT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Arrivaltime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("ARRIVALTIME");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Tripid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRIPID");

            entity.HasOne(d => d.Student).WithMany(p => p.Tripstudents)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324556");

            entity.HasOne(d => d.Trip).WithMany(p => p.Tripstudents)
                .HasForeignKey(d => d.Tripid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SYS_C00324557");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00324412");

            entity.ToTable("USERS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Birthdate)
                .HasColumnType("DATE")
                .HasColumnName("BIRTHDATE");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MIDDLENAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEX");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C00324413");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
