using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.EntityFramework.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 28, 1, 4, 23, 38, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 28, 1, 4, 23, 39, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 1, 4, 23, 37, DateTimeKind.Local).AddTicks(8978), new DateTime(2022, 10, 28, 1, 4, 23, 36, DateTimeKind.Local).AddTicks(1007) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
