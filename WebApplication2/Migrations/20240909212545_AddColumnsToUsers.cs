using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGME.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "UserState");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserState",
                table: "Users",
                newName: "PhoneNumber");
        }
    }
}
