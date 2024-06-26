﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneCatalog.Infrastructure.Data;

#nullable disable

namespace PhoneCatalog.Infrastructure.Migrations
{
    [DbContext(typeof(PhoneCatalogDbContext))]
    [Migration("20240408095156_DataSeeded")]
    partial class DataSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e62a6e71-30ad-4f8a-8439-5d74c485187d",
                            Email = "owner@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "owner@mail.com",
                            NormalizedUserName = "owner@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAENa66s0ZW6poeEHW3Biei6UbRBNGTBWjtn9Eh5RjQtZGhiLk83Dsvit246Iy79j+GQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a06643f5-d885-45f4-bc3e-ed6b205c427b",
                            TwoFactorEnabled = false,
                            UserName = "owner@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4145caa1-bb58-49bc-8218-08c90d225399",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBQLsX60x1wL9q4ETUlmam6HORk+YgrxUKdzgq+BjtVz1PmwPRW4kV2At3aeuK64vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "89cd7dab-5cbb-4faa-9b5b-43ad54a3ff04",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.CategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("CategoryTypes");

                    b.HasComment("Phone category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SmartPhone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MobilePhone"
                        });
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Coment text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasComment("Owner identifier");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int")
                        .HasComment("Phone identifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Comments");

                    b.HasComment("Phone comment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentText = "This phone is very good for me. Its very fast and have a good camera for photo!",
                            OwnerId = 3,
                            PhoneId = 1
                        });
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Owner identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Owner Phone number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Owners");

                    b.HasComment("Phone Owner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "0882515555",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 2,
                            PhoneNumber = "0882616666",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 3,
                            PhoneNumber = "0888777444",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Phone identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Battery")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone battery");

                    b.Property<string>("CameraPxl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone camera pixels");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int")
                        .HasComment("Phone identifier");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone processor");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone RAM memory");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone storage");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Performances");

                    b.HasComment("Phone Performance");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Battery = "Lithium ion batteries 4000mAh",
                            CameraPxl = "12MP Ultra Wide",
                            PhoneId = 1,
                            Processor = "6‑Core CPU 2 performance 4 efficiency Core",
                            Ram = "6 GB ",
                            Storage = "256 GB"
                        },
                        new
                        {
                            Id = 2,
                            Battery = "Lithium ion batteries 5000mAh",
                            CameraPxl = "200.0 MP + 50.0 MP + 12.0 MP + 10.0 MP",
                            PhoneId = 2,
                            Processor = "8 Core 3.39GHz",
                            Ram = "8 GB ",
                            Storage = "512 GB"
                        },
                        new
                        {
                            Id = 3,
                            Battery = " 1450 mAh",
                            CameraPxl = "No Camera",
                            PhoneId = 3,
                            Processor = "1 Core",
                            Ram = "512MB ",
                            Storage = "16 GB"
                        });
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Phone identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone brand");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Phone category identifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Phone image URL");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Phone model");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasComment("Owner identifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Phone price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Phones");

                    b.HasComment("Phone to publish");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Iphone",
                            CategoryId = 1,
                            ImageUrl = "https://buybest.bg/storage/public/uploads/media-manager/app-modules-shop-models-optiongroups/2252/4108/iphone-14-red-prod.png",
                            Model = "14",
                            OwnerId = 1,
                            Price = 1500m
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Samsung",
                            CategoryId = 1,
                            ImageUrl = "https://s13emagst.akamaized.net/products/64817/64816457/images/res_e68a0194a894e1d6b8e13ee37aad5d58.jpg",
                            Model = "Galaxy S24 Ultra",
                            OwnerId = 2,
                            Price = 2000m
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Nokia",
                            CategoryId = 2,
                            ImageUrl = "https://www.infinitygsm.ro/wp-content/uploads/2023/08/Nokia-150-2023-Black.jpg",
                            Model = "150 2023",
                            OwnerId = 3,
                            Price = 100m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("PhoneCatalog.Infrastructure.Data.Models.Owner", "Owner")
                        .WithMany("Comments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PhoneCatalog.Infrastructure.Data.Models.Phone", "Phone")
                        .WithMany("Comments")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Owner", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Performance", b =>
                {
                    b.HasOne("PhoneCatalog.Infrastructure.Data.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Phone", b =>
                {
                    b.HasOne("PhoneCatalog.Infrastructure.Data.Models.CategoryType", "CategoryType")
                        .WithMany("Phones")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PhoneCatalog.Infrastructure.Data.Models.Owner", "Owner")
                        .WithMany("Phones")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryType");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.CategoryType", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Owner", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("PhoneCatalog.Infrastructure.Data.Models.Phone", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
