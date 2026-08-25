using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Airlines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Airlines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Airlines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Airlines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Airlines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Airlines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Airlines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Airlines");
        }
    }
}
