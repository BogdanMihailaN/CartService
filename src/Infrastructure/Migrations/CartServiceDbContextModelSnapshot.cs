﻿// <auto-generated />
using System;
using CartService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CartService.Infrastructure.Migrations
{
    [DbContext(typeof(CartServiceDbContext))]
    partial class CartServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartService.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippingCost = 5.0m,
                            TaxAmount = 0.0m,
                            TotalDiscount = 0.0m,
                            TotalPrice = 0.0m,
                            UpdatedAt = new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CartService.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("CartId1")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(18,2)")
                        .HasComputedColumnSql("[Price] * [Quantity]");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CartId1");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CartId = 1,
                            Discount = 0.0m,
                            Price = 10.0m,
                            ProductId = 2,
                            ProductImageUrl = "https://example.com/product1.jpg",
                            ProductName = "Product 1",
                            Quantity = 1,
                            TotalDiscount = 0.0m,
                            TotalPrice = 10.0m
                        },
                        new
                        {
                            Id = 2,
                            CartId = 1,
                            Discount = 5.0m,
                            Price = 20.0m,
                            ProductId = 3,
                            ProductImageUrl = "https://example.com/product2.jpg",
                            ProductName = "Product 2",
                            Quantity = 2,
                            TotalDiscount = 10.0m,
                            TotalPrice = 40.0m
                        });
                });

            modelBuilder.Entity("CartService.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("CartService.Domain.Entities.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CartService.Domain.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId1");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("CartService.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
