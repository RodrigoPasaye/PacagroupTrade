using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pacagroup.Trade.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 15, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 20, 10, 59, 428, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 20, 10, 59, 429, DateTimeKind.Utc).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 20, 10, 59, 429, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactTime",
                value: new DateTime(2026, 6, 18, 20, 10, 59, 429, DateTimeKind.Utc).AddTicks(309));
        }
    }
}
