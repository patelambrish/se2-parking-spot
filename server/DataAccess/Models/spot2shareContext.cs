using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
  public partial class spot2shareContext : DbContext
  {
    public virtual DbSet<Associate> Associate { get; set; }
    public virtual DbSet<Registration> Registration { get; set; }
    public virtual DbSet<Spot> Spot { get; set; }
    public virtual DbSet<AuthToken> AuthToken { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
      optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=spot2share;;User ID=SA;Password=Calgolf12!;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Associate>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.Email).HasMaxLength(255);

        entity.Property(e => e.FirstName).HasMaxLength(255);

        entity.Property(e => e.LastName).HasMaxLength(255);

        entity.Property(e => e.PreviousAssignedStall)
                  .HasColumnName("previous_assigned_stall")
                  .HasMaxLength(255);
      });

      modelBuilder.Entity<Registration>(entity =>
      {
        entity.Property(e => e.EmailAddress)
                  .IsRequired()
                  .HasMaxLength(50);

        entity.Property(e => e.MobileNumber)
                  .IsRequired()
                  .HasMaxLength(15);

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50);

              //entity.Property(e => e.Spot)
              //    .IsRequired()
              //    .HasMaxLength(20);

              entity.Property(e => e.IsActive).HasDefaultValueSql("0");

        entity.Property(e => e.UpdateDate).HasColumnType("datetime");
      });

      modelBuilder.Entity<Spot>(entity =>
      {
        entity.Property(e => e.Id).HasColumnName("ID");

        entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

        entity.Property(e => e.Lot).HasMaxLength(32);

        entity.Property(e => e.ReservedReason).HasMaxLength(255);

        entity.HasOne(d => d.Associate)
                  .WithMany(p => p.Spot)
                  .HasForeignKey(d => d.AssociateId)
                  .HasConstraintName("FK_Associate_Spot");
      });

      modelBuilder.Entity<AuthToken>(entity =>
      {
        entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        entity.Property(e => e.EmailAddress).HasMaxLength(255);
        entity.Property(e => e.AccessCode).HasMaxLength(6);
      });
    }
  }
}
