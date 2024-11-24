using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGME.Migrations
{
    /// <inheritdoc />
    public partial class BaseDeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentUsers_Users_UserID",
                table: "ContentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistorys_Contents_ContentID",
                table: "UsageHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistorys_Users_UserID",
                table: "UsageHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsageHistorys",
                table: "UsageHistorys");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UsageHistorys",
                newName: "UsageHistories");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "User",
                newName: "IX_User_UserTypeId");

            migrationBuilder.RenameColumn(
                name: "HistoryID",
                table: "UsageHistories",
                newName: "UsageHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistorys_UserID",
                table: "UsageHistories",
                newName: "IX_UsageHistories_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistorys_ContentID",
                table: "UsageHistories",
                newName: "IX_UsageHistories_ContentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsageHistories",
                table: "UsageHistories",
                column: "UsageHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentUsers_User_UserID",
                table: "ContentUsers",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistories_Contents_ContentID",
                table: "UsageHistories",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistories_User_UserID",
                table: "UsageHistories",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserTypes_UserTypeId",
                table: "User",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentUsers_User_UserID",
                table: "ContentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistories_Contents_ContentID",
                table: "UsageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistories_User_UserID",
                table: "UsageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_UserTypeId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsageHistories",
                table: "UsageHistories");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UsageHistories",
                newName: "UsageHistorys");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.RenameColumn(
                name: "UsageHistoryID",
                table: "UsageHistorys",
                newName: "HistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistories_UserID",
                table: "UsageHistorys",
                newName: "IX_UsageHistorys_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistories_ContentID",
                table: "UsageHistorys",
                newName: "IX_UsageHistorys_ContentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Contents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsageHistorys",
                table: "UsageHistorys",
                column: "HistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentUsers_Users_UserID",
                table: "ContentUsers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistorys_Contents_ContentID",
                table: "UsageHistorys",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistorys_Users_UserID",
                table: "UsageHistorys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
