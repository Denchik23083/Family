﻿// <auto-generated />
using System;
using Family.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Family.Db.Migrations
{
    [DbContext(typeof(FamilyContext))]
    partial class FamilyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Family.Db.Entities.Auth.RefreshToken", b =>
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

            modelBuilder.Entity("Family.Db.Entities.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

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

            modelBuilder.Entity("Family.Db.Entities.Auth.RolePermission", b =>
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

                    b.ToTable("RolePermissions");

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
                            PermissionType = 8,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 10,
                            PermissionType = 0,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 11,
                            PermissionType = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 12,
                            PermissionType = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 13,
                            PermissionType = 3,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 14,
                            PermissionType = 4,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 15,
                            PermissionType = 5,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 16,
                            PermissionType = 6,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 17,
                            PermissionType = 0,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 18,
                            PermissionType = 2,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 19,
                            PermissionType = 3,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 20,
                            PermissionType = 4,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 21,
                            PermissionType = 5,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 22,
                            PermissionType = 0,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 23,
                            PermissionType = 2,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 24,
                            PermissionType = 0,
                            RoleId = 5
                        },
                        new
                        {
                            Id = 25,
                            PermissionType = 1,
                            RoleId = 5
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Users.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "god@gmail.com",
                            FirstName = "God",
                            GenderId = 1,
                            Password = "0000",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDay = new DateTime(1993, 12, 24, 17, 17, 37, 155, DateTimeKind.Local).AddTicks(2450),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            GenderId = 1,
                            Password = "0000",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            BirthDay = new DateTime(1976, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alex@gmail.com",
                            FirstName = "Alex",
                            GenderId = 1,
                            Password = "0000",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 4,
                            BirthDay = new DateTime(1976, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anna@gmail.com",
                            FirstName = "Anna",
                            GenderId = 2,
                            Password = "0000",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 5,
                            BirthDay = new DateTime(2003, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "denis@gmail.com",
                            FirstName = "Denis",
                            GenderId = 1,
                            Password = "0000",
                            RoleId = 4
                        },
                        new
                        {
                            Id = 6,
                            BirthDay = new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "daria@gmail.com",
                            FirstName = "Daria",
                            GenderId = 2,
                            Password = "0000",
                            RoleId = 4
                        },
                        new
                        {
                            Id = 7,
                            BirthDay = new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testParent@gmail.com",
                            FirstName = "TestParent",
                            GenderId = 1,
                            Password = "0000",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 8,
                            BirthDay = new DateTime(2015, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testChild@gmail.com",
                            FirstName = "TestChild",
                            GenderId = 2,
                            Password = "0000",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Children");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenusId = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 2,
                            GenusId = 1,
                            UserId = 6
                        },
                        new
                        {
                            Id = 3,
                            GenusId = 2,
                            UserId = 8
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kudryavovs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TestGenus"
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenusId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            GenusId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            GenusId = 2,
                            UserId = 7
                        });
                });

            modelBuilder.Entity("Family.Db.Entities.Auth.RefreshToken", b =>
                {
                    b.HasOne("Family.Db.Entities.Users.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Family.Db.Entities.Auth.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family.Db.Entities.Auth.RolePermission", b =>
                {
                    b.HasOne("Family.Db.Entities.Auth.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Family.Db.Entities.Users.User", b =>
                {
                    b.HasOne("Family.Db.Entities.Users.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Auth.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Child", b =>
                {
                    b.HasOne("Family.Db.Entities.Web.Genus", "Genus")
                        .WithMany("Children")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Users.User", "User")
                        .WithOne("Child")
                        .HasForeignKey("Family.Db.Entities.Web.Child", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Parent", b =>
                {
                    b.HasOne("Family.Db.Entities.Web.Genus", "Genus")
                        .WithMany("Parents")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Db.Entities.Users.User", "User")
                        .WithOne("Parent")
                        .HasForeignKey("Family.Db.Entities.Web.Parent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family.Db.Entities.Auth.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Family.Db.Entities.Users.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Family.Db.Entities.Users.User", b =>
                {
                    b.Navigation("Child");

                    b.Navigation("Parent");

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("Family.Db.Entities.Web.Genus", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}
