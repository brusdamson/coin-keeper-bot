﻿// <auto-generated />
using System;
using FinancialBot.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialBot.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240218165327_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinancialBot.Domain.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("FinancialBot.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FinancialBot.Domain.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("FinancialBot.Domain.PurchaseProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseProducts");
                });

            modelBuilder.Entity("ProductPurchase", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchasesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductsId", "PurchasesId");

                    b.HasIndex("PurchasesId");

                    b.ToTable("ProductPurchase");
                });

            modelBuilder.Entity("FinancialBot.Domain.PurchaseProduct", b =>
                {
                    b.HasOne("FinancialBot.Domain.Product", "Product")
                        .WithMany("PurchaseProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialBot.Domain.Purchase", "Purchase")
                        .WithMany("PurchaseProducts")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("ProductPurchase", b =>
                {
                    b.HasOne("FinancialBot.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialBot.Domain.Purchase", null)
                        .WithMany()
                        .HasForeignKey("PurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinancialBot.Domain.Product", b =>
                {
                    b.Navigation("PurchaseProducts");
                });

            modelBuilder.Entity("FinancialBot.Domain.Purchase", b =>
                {
                    b.Navigation("PurchaseProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
