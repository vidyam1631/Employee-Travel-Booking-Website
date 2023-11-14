using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_TravelBookingProject_.Models
{
    public partial class TicketBooking_DbContext : DbContext
    {
        public TicketBooking_DbContext()
        {
        }

        public TicketBooking_DbContext(DbContextOptions<TicketBooking_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<TravelRequest> TravelRequests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=TicketBooking_Db; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__1299A861815E419B");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("emp_address");

                entity.Property(e => e.EmpContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emp_contact");

                entity.Property(e => e.EmpDob)
                    .HasColumnType("date")
                    .HasColumnName("emp_dob");

                entity.Property(e => e.EmpFname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emp_Fname");

                entity.Property(e => e.EmpLname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emp_Lname");
            });

            modelBuilder.Entity<TravelRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__travelRe__18D3B90F35A349C5");

                entity.ToTable("travelRequest");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approval_Status");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("booking_Status");

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("current_Status");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.LocationFrom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("location_From");

                entity.Property(e => e.LocationTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("location_To");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TravelRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__travelReq__emp_i__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
