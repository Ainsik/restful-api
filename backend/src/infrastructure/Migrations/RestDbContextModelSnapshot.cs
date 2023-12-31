﻿using infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace infrastructure.Migrations;

[DbContext(typeof(RestDbContext))]
partial class RestDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.5")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("api.Entities.Address", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<string>("City")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            b.Property<int>("DoctorId")
                .HasColumnType("int");

            b.Property<string>("PostalCode")
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("nchar(6)")
                .IsFixedLength();

            b.Property<string>("Street")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            b.HasKey("Id");

            b.HasIndex("DoctorId")
                .IsUnique();

            b.ToTable("Addresses");
        });

        modelBuilder.Entity("api.Entities.Doctor", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<string>("FirstName")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("LastName")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("Phone")
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnType("nchar(9)")
                .IsFixedLength();

            b.Property<string>("Specialization")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.HasKey("Id");

            b.ToTable("Doctors");
        });

        modelBuilder.Entity("api.Entities.Address", b =>
        {
            b.HasOne("api.Entities.Doctor", "Doctor")
                .WithOne("Address")
                .HasForeignKey("api.Entities.Address", "DoctorId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Doctor");
        });

        modelBuilder.Entity("api.Entities.Doctor", b =>
        {
            b.Navigation("Address")
                .IsRequired();
        });
#pragma warning restore 612, 618
    }
}