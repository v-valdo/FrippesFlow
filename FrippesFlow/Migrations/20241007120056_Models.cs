using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrippesFlow.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientsPer10k",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Milk = table.Column<double>(type: "REAL", nullable: false),
                    Flour = table.Column<double>(type: "REAL", nullable: false),
                    Yeast = table.Column<double>(type: "REAL", nullable: false),
                    Butter = table.Column<double>(type: "REAL", nullable: false),
                    Salt = table.Column<double>(type: "REAL", nullable: false),
                    Water = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsPer10k", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyExpenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Salary = table.Column<double>(type: "REAL", nullable: false),
                    Electricity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCosts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MilkPerLitre = table.Column<double>(type: "REAL", nullable: false),
                    FlourPerKg = table.Column<double>(type: "REAL", nullable: false),
                    YeastPerKg = table.Column<double>(type: "REAL", nullable: false),
                    SaltPerKg = table.Column<double>(type: "REAL", nullable: false),
                    WaterPerM3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductionCost = table.Column<double>(type: "REAL", nullable: false),
                    TotalIncome = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsPer10k");

            migrationBuilder.DropTable(
                name: "MonthlyExpenses");

            migrationBuilder.DropTable(
                name: "ProductionCosts");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
