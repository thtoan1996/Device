using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeviceApp.Models
{
    public partial class DeviceContext : DbContext
    {
        public DeviceContext()
        {
        }

        public DeviceContext(DbContextOptions<DeviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeviceCategories> DeviceCategories { get; set; }
        public virtual DbSet<DeviceDetails> DeviceDetails { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=THTOAN\\MSSQLSERVER1;Database=Device;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceCategories>(entity =>
            {
                entity.HasKey(e => e.DCId);

                entity.ToTable("Device_Categories");

                entity.Property(e => e.DCId).HasColumnName("D_C_Id");

                entity.Property(e => e.DCName)
                    .IsRequired()
                    .HasColumnName("D_C_Name");

                entity.Property(e => e.DCStatus).HasColumnName("D_C_Status");
            });

            modelBuilder.Entity<DeviceDetails>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.DId });

                entity.ToTable("Device_Details");

                entity.Property(e => e.UId).HasColumnName("U_Id");

                entity.Property(e => e.DId).HasColumnName("D_Id");

                entity.Property(e => e.DDDateTime)
                    .HasColumnName("D_D_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDOperated)
                    .IsRequired()
                    .HasColumnName("D_D_Operated")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.D)
                    .WithMany(p => p.DeviceDetails)
                    .HasForeignKey(d => d.DId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Details_Devices");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.DeviceDetails)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Details_Users");
            });

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.HasKey(e => e.DId);

                entity.Property(e => e.DId).HasColumnName("D_Id");

                entity.Property(e => e.DBandwidth).HasColumnName("D_Bandwidth");

                entity.Property(e => e.DCId).HasColumnName("D_C_Id");

                entity.Property(e => e.DName)
                    .IsRequired()
                    .HasColumnName("D_Name");

                entity.Property(e => e.DPrice).HasColumnName("D_Price");

                entity.Property(e => e.DProducer)
                    .IsRequired()
                    .HasColumnName("D_Producer")
                    .HasMaxLength(20);

                entity.Property(e => e.DStatus).HasColumnName("D_Status");

                entity.Property(e => e.DWarranty).HasColumnName("D_Warranty");

                entity.HasOne(d => d.DC)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DCId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_Device_Categories");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UId);

                entity.Property(e => e.UId).HasColumnName("U_Id");

                entity.Property(e => e.UAddress)
                    .HasColumnName("U_Address")
                    .HasMaxLength(250);

                entity.Property(e => e.UBirthDay)
                    .HasColumnName("U_BirthDay")
                    .HasColumnType("datetime");

                entity.Property(e => e.UEmail)
                    .IsRequired()
                    .HasColumnName("U_Email")
                    .HasMaxLength(250);

                entity.Property(e => e.UFullName)
                    .IsRequired()
                    .HasColumnName("U_FullName")
                    .HasMaxLength(50);

                entity.Property(e => e.UPassword)
                    .IsRequired()
                    .HasColumnName("U_Password")
                    .HasMaxLength(50);

                entity.Property(e => e.UPhone)
                    .HasColumnName("U_Phone")
                    .HasMaxLength(15);

                entity.Property(e => e.UStatus).HasColumnName("U_Status");

                entity.Property(e => e.UUserName)
                    .IsRequired()
                    .HasColumnName("U_UserName")
                    .HasMaxLength(50);
            });
        }
    }
}
