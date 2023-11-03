using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serkanbilsel.Migrations
{
    /// <inheritdoc />
    public partial class sbiocommentupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 11, 3, 16, 36, 17, 658, DateTimeKind.Local).AddTicks(1866), new Guid("d0560bdf-1ef8-49f0-9a59-18fe8d17ad6c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 11, 3, 15, 30, 18, 128, DateTimeKind.Local).AddTicks(7501), new Guid("f3c393bd-8b1e-4602-89d8-9b52428fa508") });
        }
    }
}
