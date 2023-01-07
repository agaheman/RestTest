﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestTest.Infra.Data.Sql.Command;

#nullable disable

namespace RestTest.Infra.Data.Sql.Command.Migrations
{
    [DbContext(typeof(RestTestCommandContext))]
    partial class RestTestCommandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestTest.Core.Domain.Employees.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("bigint")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "TaherSamadi@gmail.com",
                            FirstName = "Taher",
                            LastName = "Samadi",
                            NationalCode = 2660039991L
                        },
                        new
                        {
                            Id = 2,
                            Email = "AmirHosseinLesani@gmail.com",
                            FirstName = "AmirHossein",
                            LastName = "Lesani",
                            NationalCode = 2660039993L
                        },
                        new
                        {
                            Id = 3,
                            Email = "NimaKhandabi@gmail.com",
                            FirstName = "Nima",
                            LastName = "Khandabi",
                            NationalCode = 2660039995L
                        });
                });

            modelBuilder.Entity("RestTest.Core.Domain.Notes.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Published")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Note");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Chekhof1",
                            EmployeeId = 1,
                            Name = "Montakhab1",
                            Published = true
                        },
                        new
                        {
                            Id = 2,
                            Content = "Chekhof2",
                            EmployeeId = 1,
                            Name = "Dibache2",
                            Published = false
                        },
                        new
                        {
                            Id = 3,
                            Content = "Veronic1",
                            EmployeeId = 2,
                            Name = "Montakhab3",
                            Published = true
                        },
                        new
                        {
                            Id = 4,
                            Content = "Veronic2",
                            EmployeeId = 2,
                            Name = "Dibache4",
                            Published = true
                        },
                        new
                        {
                            Id = 5,
                            Content = "LastState1",
                            EmployeeId = 3,
                            Name = "Montakhab5",
                            Published = true
                        },
                        new
                        {
                            Id = 6,
                            Content = "LastState2",
                            EmployeeId = 3,
                            Name = "Dibache6",
                            Published = true
                        });
                });

            modelBuilder.Entity("RestTest.Core.Domain.Notes.Entities.Note", b =>
                {
                    b.HasOne("RestTest.Core.Domain.Employees.Entities.Employee", "Employee")
                        .WithMany("Notes")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RestTest.Core.Domain.Employees.Entities.Employee", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}