using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.EntityFramework.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Feedback");

            migrationBuilder.AddColumn<string>(
                name: "FeedbackName",
                table: "Feedback",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FeedbackDate", "FeedbackName", "FeedbackType" },
                values: new object[] { new DateTime(2022, 10, 29, 0, 26, 1, 253, DateTimeKind.Local).AddTicks(5849), "Visszajelzés", "Hiba" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 29, 0, 26, 1, 257, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 0, 26, 1, 257, DateTimeKind.Local).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 29, 0, 26, 1, 256, DateTimeKind.Local).AddTicks(8612), new DateTime(2022, 10, 29, 0, 26, 1, 256, DateTimeKind.Local).AddTicks(8064) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackName",
                table: "Feedback");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Feedback",
                type: "double",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FeedbackDate", "FeedbackType", "Rate" },
                values: new object[] { new DateTime(2022, 10, 28, 14, 55, 29, 530, DateTimeKind.Local).AddTicks(3286), "Visszajelzés", 2.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 28, 14, 55, 29, 533, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 28, 14, 55, 29, 533, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 14, 55, 29, 533, DateTimeKind.Local).AddTicks(4758), new DateTime(2022, 10, 28, 14, 55, 29, 533, DateTimeKind.Local).AddTicks(4266) });
        }
    }
}
