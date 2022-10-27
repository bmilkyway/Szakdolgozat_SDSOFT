using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.EntityFramework.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tasks",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 27, 23, 37, 51, 690, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 23, 37, 51, 690, DateTimeKind.Local).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 27, 23, 37, 51, 689, DateTimeKind.Local).AddTicks(4979), new DateTime(2022, 10, 27, 23, 37, 51, 687, DateTimeKind.Local).AddTicks(5712) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 9, 9, 22, 56, 18, 437, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 9, 9, 22, 56, 18, 437, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 56, 18, 436, DateTimeKind.Local).AddTicks(2340), new DateTime(2022, 9, 9, 22, 56, 18, 432, DateTimeKind.Local).AddTicks(8176) });
        }
    }
}
