﻿// <auto-generated />
using Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cars.Migrations
{
    [DbContext(typeof(CarDb))]
    [Migration("20200210202725_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Cars.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("City")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Combined")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cylinders")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Displacement")
                        .HasColumnType("REAL");

                    b.Property<int>("Highway")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
