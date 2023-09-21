﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentSystemApi_v01;

#nullable disable

namespace PaymentSystemApi_v01.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230920102244_Transactions History ")]
    partial class TransactionsHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaymentSystemApi_v01.Core.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PaymentSystemApi_v01.Core.Marchant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("AverageTransactionVolume")
                        .HasColumnType("float");

                    b.Property<string>("BusinessId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarchantNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MarchantNumber")
                        .IsUnique();

                    b.ToTable("Marchants");
                });

            modelBuilder.Entity("PaymentSystemApi_v01.Core.TransactionHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustormId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustormId");

                    b.ToTable("transactionHistories");
                });

            modelBuilder.Entity("PaymentSystemApi_v01.Core.TransactionHistory", b =>
                {
                    b.HasOne("PaymentSystemApi_v01.Core.Customer", "Customer")
                        .WithMany("TransactionHistory")
                        .HasForeignKey("CustormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PaymentSystemApi_v01.Core.Customer", b =>
                {
                    b.Navigation("TransactionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
