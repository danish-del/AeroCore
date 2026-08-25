using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAirport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportId",
                table: "Airlines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportId",
                table: "Aircrafts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_AirportId",
                table: "Airlines",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirportId",
                table: "Aircrafts",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Airports_AirportId",
                table: "Aircrafts",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airlines_Airports_AirportId",
                table: "Airlines",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Airports_AirportId",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Airlines_Airports_AirportId",
                table: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airlines_AirportId",
                table: "Airlines");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_AirportId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Aircrafts");
        }
    }
}
