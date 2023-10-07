﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalmonCookies.Data;

#nullable disable

namespace SalmonCookies.Migrations
{
    [DbContext(typeof(SalmonCookieDbContext))]
    [Migration("20231004163453_addEntities")]
    partial class addEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalmonCookies.Models.CookieStands", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("average_cookies_per_sale")
                        .HasColumnType("float");

                    b.Property<int>("maximum_customers_per_hour")
                        .HasColumnType("int");

                    b.Property<int>("minimum_customers_per_hour")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Cookiestands");
                });

            modelBuilder.Entity("SalmonCookies.Models.HourlySales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CookieStandsId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CookieStandsId");

                    b.ToTable("HourlySales");
                });

            modelBuilder.Entity("SalmonCookies.Models.HourlySales", b =>
                {
                    b.HasOne("SalmonCookies.Models.CookieStands", "Stands")
                        .WithMany("HourlySales")
                        .HasForeignKey("CookieStandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stands");
                });

            modelBuilder.Entity("SalmonCookies.Models.CookieStands", b =>
                {
                    b.Navigation("HourlySales");
                });
#pragma warning restore 612, 618
        }
    }
}
