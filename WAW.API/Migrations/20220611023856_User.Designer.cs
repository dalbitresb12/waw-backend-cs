﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAW.API.Weather.Persistence.Contexts;

#nullable disable

namespace WAW.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220611023856_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .HasColumnType("longtext")
                        .HasColumnName("about");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext")
                        .HasColumnName("biography");

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_name");

                    b.Property<string>("Location")
                        .HasColumnType("longtext")
                        .HasColumnName("location");

                    b.Property<string>("PreferredName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("preferred_name");

                    b.HasKey("Id")
                        .HasName("p_k_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WAW.API.Weather.Domain.Models.Forecast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext")
                        .HasColumnName("summary");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("int")
                        .HasColumnName("temperature_c");

                    b.HasKey("Id")
                        .HasName("p_k_forecasts");

                    b.ToTable("forecasts", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}