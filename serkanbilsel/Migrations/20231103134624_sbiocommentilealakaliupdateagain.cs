using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serkanbilsel.Migrations
{
    /// <inheritdoc />
    public partial class sbiocommentilealakaliupdateagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 11, 3, 16, 46, 23, 801, DateTimeKind.Local).AddTicks(2791), new Guid("167b5f42-f898-47a1-990c-dcc9a365feb0") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 11, 3, 16, 36, 17, 658, DateTimeKind.Local).AddTicks(1866), new Guid("d0560bdf-1ef8-49f0-9a59-18fe8d17ad6c") });
        }
    }
}
