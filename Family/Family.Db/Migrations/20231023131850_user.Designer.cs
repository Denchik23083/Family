﻿// <auto-generated />
using System;
using Family.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Family.Db.Migrations
{
    [DbContext(typeof(FamilyContext))]
    [Migration("20231023131850_user")]
    partial class user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Family.Db.Entities.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int?>("GenusId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("GenusId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("Family.Db.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenderType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);

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

            modelBuilder.Entity("Family.Db.Entities.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FatherId")
                        .HasColumnType("int");

                    b.Property<int>("MotherId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genus");
                });

            modelBuilder.Entity("Family.Db.Entities.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                });

            modelBuilder.Entity("Family.Db.Entities.ParentsChildren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParentsChildren");
                });

            modelBuilder.Entity("Family.Db.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Value")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Family.Db.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleType = 0
                        },
                        new
                        {
                            Id = 2,
                            RoleType = 1
                        },
                        new
                        {
                            Id = 3,
                            RoleType = 2
                        },
                        new
                        {
                            Id = 4,
                            RoleType = 3
                        },
                        new
                        {
                            Id = 5,
                            RoleType = 4
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PermissionType")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionType = 0,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            PermissionType = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            PermissionType = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            PermissionType = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            PermissionType = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            PermissionType = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 7,
                            PermissionType = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 8,
                            PermissionType = 7,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 9,
                            PermissionType = 0,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 10,
                            PermissionType = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 11,
                            PermissionType = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 12,
                            PermissionType = 3,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 13,
                            PermissionType = 4,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 14,
                            PermissionType = 5,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 15,
                            PermissionType = 0,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 16,
                            PermissionType = 1,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 17,
                            PermissionType = 2,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 18,
                            PermissionType = 3,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 19,
                            PermissionType = 0,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 20,
                            PermissionType = 1,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 21,
                            PermissionType = 0,
                            RoleId = 5
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 5000,
                            Email = "god@gmail.com",
                            FirstName = "God",
                            GenderId = 1,
                            LastName = "Full",
                            Password = "0000",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            GenderId = 1,
                            LastName = "Full",
                            Password = "0000",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Age = 45,
                            Email = "alex@gmail.com",
                            FirstName = "Alex",
                            GenderId = 1,
                            LastName = "Kudryavov",
                            Password = "0000",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 4,
                            Age = 45,
                            Email = "anna@gmail.com",
                            FirstName = "Anna",
                            GenderId = 2,
                            LastName = "Kudryavova",
                            Password = "0000",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 5,
                            Age = 20,
                            Email = "denis@gmail.com",
                            FirstName = "Denis",
                            GenderId = 1,
                            LastName = "Kudryavov",
                            Password = "0000",
                            RoleId = 4
                        },
                        new
                        {
                            Id = 6,
                            Age = 4,
                            Email = "daria@gmail.com",
                            FirstName = "Daria",
                            GenderId = 2,
                            LastName = "Kudryavova",
                            Password = "0000",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Child", b =>
                {
                    b.HasOne("Family.Db.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Genus", "Genus")
                        .WithMany("Children")
                        .HasForeignKey("GenusId");

                    b.Navigation("Gender");

                    b.Navigation("Genus");
                });

            modelBuilder.Entity("Family.Db.Entities.Parent", b =>
                {
                    b.HasOne("Family.Db.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Family.Db.Entities.RefreshToken", b =>
                {
                    b.HasOne("Family.Db.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Family.Db.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family.Db.Entities.RolePermission", b =>
                {
                    b.HasOne("Family.Db.Entities.Role", "Role")
                        .WithMany("RolePermission")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Family.Db.Entities.User", b =>
                {
                    b.HasOne("Family.Db.Entities.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Family.Db.Entities.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Family.Db.Entities.Genus", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Family.Db.Entities.Role", b =>
                {
                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Family.Db.Entities.User", b =>
                {
                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
