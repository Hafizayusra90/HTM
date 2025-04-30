using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HTM.Models;

public partial class HmanagementSystemdbContext : DbContext
{
    public HmanagementSystemdbContext()
    {
    }

    public HmanagementSystemdbContext(DbContextOptions<HmanagementSystemdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Bookingdate> Bookingdates { get; set; }

    public virtual DbSet<Bookingstatus> Bookingstatuses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Housekeeping> Housekeepings { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Inventorycategory> Inventorycategories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentmethod> Paymentmethods { get; set; }

    public virtual DbSet<Paymentstatus> Paymentstatuses { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomstatus> Roomstatuses { get; set; }

    public virtual DbSet<Roomytype> Roomytypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseNpgsql("Host=ep-tiny-recipe-a4bp5uoa-pooler.us-east-1.aws.neon.tech;Database=HManagementSystemdb;Username=HManagementSystemdb_owner;Password=npg_9GJdfczb3Lkg");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("bookings_pkey");

            entity.ToTable("bookings");

            entity.Property(e => e.Bookingid)
                .ValueGeneratedNever()
                .HasColumnName("bookingid");
            entity.Property(e => e.Guestid).HasColumnName("guestid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Guest).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Guestid)
                .HasConstraintName("bookings_guestid_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("bookings_roomid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Statusid)
                .HasConstraintName("bookings_statusid_fkey");
        });

        modelBuilder.Entity<Bookingdate>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("bookingdates_pkey");

            entity.ToTable("bookingdates");

            entity.Property(e => e.Bookingid)
                .ValueGeneratedNever()
                .HasColumnName("bookingid");
            entity.Property(e => e.Checkindate).HasColumnName("checkindate");
            entity.Property(e => e.Checkoutdate).HasColumnName("checkoutdate");
        });

        modelBuilder.Entity<Bookingstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("bookingstatus_pkey");

            entity.ToTable("bookingstatus");

            entity.Property(e => e.Statusid)
                .ValueGeneratedNever()
                .HasColumnName("statusid");
            entity.Property(e => e.Statusname)
                .HasMaxLength(20)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptid).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Deptid)
                .ValueGeneratedNever()
                .HasColumnName("deptid");
            entity.Property(e => e.Deptname)
                .HasMaxLength(50)
                .HasColumnName("deptname");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Feedbackid).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.Feedbackid)
                .ValueGeneratedNever()
                .HasColumnName("feedbackid");
            entity.Property(e => e.Commentt)
                .HasMaxLength(200)
                .HasColumnName("commentt");
            entity.Property(e => e.Fbdate).HasColumnName("fbdate");
            entity.Property(e => e.Guestid).HasColumnName("guestid");
            entity.Property(e => e.Rating)
                .HasPrecision(90)
                .HasColumnName("rating");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");

            entity.HasOne(d => d.Guest).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Guestid)
                .HasConstraintName("feedback_guestid_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Serviceid)
                .HasConstraintName("feedback_serviceid_fkey");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Guestid).HasName("guests_pkey");

            entity.ToTable("guests");

            entity.HasIndex(e => e.Contactno, "guests_contactno_key").IsUnique();

            entity.HasIndex(e => e.Email, "guests_email_key").IsUnique();

            entity.Property(e => e.Guestid)
                .ValueGeneratedNever()
                .HasColumnName("guestid");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.Contactno).HasColumnName("contactno");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Guestname)
                .HasMaxLength(30)
                .HasColumnName("guestname");
        });

        modelBuilder.Entity<Housekeeping>(entity =>
        {
            entity.HasKey(e => e.Taskid).HasName("housekeeping_pkey");

            entity.ToTable("housekeeping");

            entity.Property(e => e.Taskid)
                .ValueGeneratedNever()
                .HasColumnName("taskid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Taskdate).HasColumnName("taskdate");
            entity.Property(e => e.Taskdescription)
                .HasMaxLength(100)
                .HasColumnName("taskdescription");

            entity.HasOne(d => d.Room).WithMany(p => p.Housekeepings)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("housekeeping_roomid_fkey");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.Property(e => e.Itemid)
                .ValueGeneratedNever()
                .HasColumnName("itemid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Itemname)
                .HasMaxLength(50)
                .HasColumnName("itemname");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Reorderlevel)
                .HasMaxLength(30)
                .HasColumnName("reorderlevel");
            entity.Property(e => e.Unitcost).HasColumnName("unitcost");

            entity.HasOne(d => d.Category).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("inventory_categoryid_fkey");
        });

        modelBuilder.Entity<Inventorycategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("inventorycategory_pkey");

            entity.ToTable("inventorycategory");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedNever()
                .HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid)
                .ValueGeneratedNever()
                .HasColumnName("paymentid");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Bookingid).HasColumnName("bookingid");
            entity.Property(e => e.Paymentdate).HasColumnName("paymentdate");
            entity.Property(e => e.Paymentmethodid).HasColumnName("paymentmethodid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Bookingid)
                .HasConstraintName("payments_bookingid_fkey");

            entity.HasOne(d => d.Paymentmethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Paymentmethodid)
                .HasConstraintName("payments_paymentmethodid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Statusid)
                .HasConstraintName("payments_statusid_fkey");
        });

        modelBuilder.Entity<Paymentmethod>(entity =>
        {
            entity.HasKey(e => e.Paymentmethodid).HasName("paymentmethod_pkey");

            entity.ToTable("paymentmethod");

            entity.Property(e => e.Paymentmethodid)
                .ValueGeneratedNever()
                .HasColumnName("paymentmethodid");
            entity.Property(e => e.Paymentmethodname)
                .HasMaxLength(25)
                .HasColumnName("paymentmethodname");
        });

        modelBuilder.Entity<Paymentstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("paymentstatus_pkey");

            entity.ToTable("paymentstatus");

            entity.Property(e => e.Statusid)
                .ValueGeneratedNever()
                .HasColumnName("statusid");
            entity.Property(e => e.Statusname)
                .HasMaxLength(20)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Positionid).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.Positionid)
                .ValueGeneratedNever()
                .HasColumnName("positionid");
            entity.Property(e => e.Positionname)
                .HasMaxLength(30)
                .HasColumnName("positionname");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.Roomid)
                .ValueGeneratedNever()
                .HasColumnName("roomid");
            entity.Property(e => e.Floorno).HasColumnName("floorno");
            entity.Property(e => e.Pricepernight).HasColumnName("pricepernight");
            entity.Property(e => e.Roomno).HasColumnName("roomno");
            entity.Property(e => e.Roomtypeid).HasColumnName("roomtypeid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Roomtype).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Roomtypeid)
                .HasConstraintName("rooms_roomtypeid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Statusid)
                .HasConstraintName("rooms_statusid_fkey");
        });

        modelBuilder.Entity<Roomstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("roomstatus_pkey");

            entity.ToTable("roomstatus");

            entity.Property(e => e.Statusid)
                .ValueGeneratedNever()
                .HasColumnName("statusid");
            entity.Property(e => e.Statusname)
                .HasMaxLength(30)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<Roomytype>(entity =>
        {
            entity.HasKey(e => e.Roomtypeid).HasName("roomytypes_pkey");

            entity.ToTable("roomytypes");

            entity.Property(e => e.Roomtypeid)
                .ValueGeneratedNever()
                .HasColumnName("roomtypeid");
            entity.Property(e => e.Bedtype)
                .HasMaxLength(20)
                .HasColumnName("bedtype");
            entity.Property(e => e.Roomtypename)
                .HasMaxLength(30)
                .HasColumnName("roomtypename");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Serviceid)
                .ValueGeneratedNever()
                .HasColumnName("serviceid");
            entity.Property(e => e.Available)
                .HasMaxLength(30)
                .HasColumnName("available");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Servicename)
                .HasMaxLength(50)
                .HasColumnName("servicename");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Staffid).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.HasIndex(e => e.Contactno, "staff_contactno_key").IsUnique();

            entity.Property(e => e.Staffid)
                .ValueGeneratedNever()
                .HasColumnName("staffid");
            entity.Property(e => e.Contactno).HasColumnName("contactno");
            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Staffname)
                .HasMaxLength(50)
                .HasColumnName("staffname");

            entity.HasOne(d => d.Dept).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Deptid)
                .HasConstraintName("staff_deptid_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Positionid)
                .HasConstraintName("staff_positionid_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Supplierid).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.Contactno, "suppliers_contactno_key").IsUnique();

            entity.HasIndex(e => e.Email, "suppliers_email_key").IsUnique();

            entity.Property(e => e.Supplierid)
                .ValueGeneratedNever()
                .HasColumnName("supplierid");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Contactno).HasColumnName("contactno");
            entity.Property(e => e.Contactperson)
                .HasMaxLength(90)
                .HasColumnName("contactperson");
            entity.Property(e => e.Email)
                .HasMaxLength(90)
                .HasColumnName("email");
            entity.Property(e => e.Suppliername)
                .HasMaxLength(60)
                .HasColumnName("suppliername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
