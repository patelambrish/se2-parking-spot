using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccess.Models;

namespace DataAccess.Migrations
{
    [DbContext(typeof(spot2shareContext))]
    [Migration("20170621010232_Sync5")]
    partial class Sync5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.Associate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<bool?>("IsDowntownStall");

                    b.Property<bool>("IsStallAssigned");

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.Property<string>("PreviousAssignedStall")
                        .HasColumnName("previous_assigned_stall")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Associate");
                });

            modelBuilder.Entity("DataAccess.Models.AuthToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessCode")
                        .HasMaxLength(6);

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255);

                    b.Property<bool>("IsUsed");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("AuthToken");
                });

            modelBuilder.Entity("DataAccess.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivationKey");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("DataAccess.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("AssociateId")
                        .HasColumnName("AssociateID");

                    b.Property<bool>("IsManagerParking");

                    b.Property<string>("Lot")
                        .HasMaxLength(32);

                    b.Property<bool>("Reserved");

                    b.Property<string>("ReservedReason")
                        .HasMaxLength(255);

                    b.Property<int?>("SpotNumber");

                    b.HasKey("Id");

                    b.HasIndex("AssociateId");

                    b.ToTable("Spot");
                });

            modelBuilder.Entity("DataAccess.Models.Spot", b =>
                {
                    b.HasOne("DataAccess.Models.Associate", "Associate")
                        .WithMany("Spot")
                        .HasForeignKey("AssociateId")
                        .HasConstraintName("FK_Associate_Spot");
                });
        }
    }
}
