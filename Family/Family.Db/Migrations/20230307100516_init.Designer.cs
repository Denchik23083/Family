﻿// <auto-generated />
using Family.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Family.Db.Migrations
{
    [DbContext(typeof(FamilyContext))]
    [Migration("20230307100516_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Family.Db.Entities.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Children");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 19,
                            FirstName = "Denis",
                            GenderId = 2,
                            LastName = "Kudryavov"
                        },
                        new
                        {
                            Id = 2,
                            Age = 3,
                            FirstName = "Daria",
                            GenderId = 1,
                            LastName = "Kudryavova"
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenderType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenderType = 0
                        },
                        new
                        {
                            Id = 2,
                            GenderType = 1
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 45,
                            FirstName = "Alex",
                            GenderId = 2,
                            LastName = "Kudryavov"
                        },
                        new
                        {
                            Id = 2,
                            Age = 45,
                            FirstName = "Anna",
                            GenderId = 1,
                            LastName = "Kudryavova"
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.ParentsChildren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ParentId");

                    b.ToTable("ParentsChildren");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChildId = 1,
                            ParentId = 1
                        },
                        new
                        {
                            Id = 2,
                            ChildId = 1,
                            ParentId = 2
                        },
                        new
                        {
                            Id = 3,
                            ChildId = 2,
                            ParentId = 1
                        },
                        new
                        {
                            Id = 4,
                            ChildId = 2,
                            ParentId = 2
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Child", b =>
                {
                    b.HasOne("Family.Db.Entities.Gender", "Gender")
                        .WithMany("GenderChildren")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Family.Db.Entities.Parent", b =>
                {
                    b.HasOne("Family.Db.Entities.Gender", "Gender")
                        .WithMany("GenderParents")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Family.Db.Entities.ParentsChildren", b =>
                {
                    b.HasOne("Family.Db.Entities.Child", "Child")
                        .WithMany("ParentsChildren")
                        .HasForeignKey("ChildId")
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Parent", "Parent")
                        .WithMany("ParentsChildren")
                        .HasForeignKey("ParentId")
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Family.Db.Entities.Child", b =>
                {
                    b.Navigation("ParentsChildren");
                });

            modelBuilder.Entity("Family.Db.Entities.Gender", b =>
                {
                    b.Navigation("GenderChildren");

                    b.Navigation("GenderParents");
                });

            modelBuilder.Entity("Family.Db.Entities.Parent", b =>
                {
                    b.Navigation("ParentsChildren");
                });
#pragma warning restore 612, 618
        }
    }
}
