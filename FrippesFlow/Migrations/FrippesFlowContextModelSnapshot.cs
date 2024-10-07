﻿// <auto-generated />
using System;
using FrippesFlow.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FrippesFlow.Migrations
{
    [DbContext(typeof(FrippesFlowContext))]
    partial class FrippesFlowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FrippesFlow.Models.IngredientPer10k", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Butter")
                        .HasColumnType("REAL");

                    b.Property<double>("Flour")
                        .HasColumnType("REAL");

                    b.Property<double>("Milk")
                        .HasColumnType("REAL");

                    b.Property<double>("Salt")
                        .HasColumnType("REAL");

                    b.Property<double>("Water")
                        .HasColumnType("REAL");

                    b.Property<double>("Yeast")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("IngredientsPer10k");
                });

            modelBuilder.Entity("FrippesFlow.Models.MonthlyExpense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Electricity")
                        .HasColumnType("REAL");

                    b.Property<double>("Salary")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("MonthlyExpenses");
                });

            modelBuilder.Entity("FrippesFlow.Models.ProductionCost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("FlourPerKg")
                        .HasColumnType("REAL");

                    b.Property<double>("MilkPerLitre")
                        .HasColumnType("REAL");

                    b.Property<double>("SaltPerKg")
                        .HasColumnType("REAL");

                    b.Property<double>("WaterPerM3")
                        .HasColumnType("REAL");

                    b.Property<double>("YeastPerKg")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ProductionCosts");
                });

            modelBuilder.Entity("FrippesFlow.Models.Result", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductionCost")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalIncome")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("FrippesFlow.Models.SalesEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountSold")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PricePer")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Week")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SalesEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
