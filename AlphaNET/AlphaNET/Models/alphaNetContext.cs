using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AlphaNET.Models
{
    public partial class AlphaNetContext : DbContext
    {
        public AlphaNetContext()
        {
        }

        public AlphaNetContext(DbContextOptions<AlphaNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCards> TblCards { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCards>(entity =>
            {
                entity.ToTable("tblCards");

                entity.HasIndex(e => e.FileName)
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("File Name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ScanType)
                    .IsRequired()
                    .HasColumnName("Scan Type")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("BIGINT");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.TblCards)
                    .HasPrincipalKey<TblUsers>(p => p.Cnp)
                    .HasForeignKey<TblCards>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.HasIndex(e => e.Cnp)
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnName("Birth Date")
                    .HasColumnType("DATE");

                entity.Property(e => e.Cnp)
                    .HasColumnName("CNP")
                    .HasColumnType("BIGINT");

                entity.Property(e => e.ExpiryDate)
                    .IsRequired()
                    .HasColumnName("Expiry Date")
                    .HasColumnType("DATE");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First Name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.IdCardNumber)
                    .HasColumnName("ID Card Number")
                    .HasColumnType("BIGINT");

                entity.Property(e => e.IdCardSerial)
                    .IsRequired()
                    .HasColumnName("ID Card Serial")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.IssuanceDate)
                    .IsRequired()
                    .HasColumnName("Issuance Date")
                    .HasColumnType("DATE");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last Name")
                    .HasColumnType("VARCHAR");
            });
        }
    }
}
