using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrippesFlow.Migrations
{
    /// <inheritdoc />
    public partial class addedButterPerKiloToCOrrespondingDbTableInEf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ButterPerKg",
                table: "ProductionCosts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButterPerKg",
                table: "ProductionCosts");
        }
    }
}
