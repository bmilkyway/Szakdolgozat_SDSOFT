using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CRM.EntityFramework.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FeedbackUserId = table.Column<int>(nullable: false),
                    FeedbackDescription = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: true),
                    FeedbackDate = table.Column<DateTime>(nullable: true),
                    isRead = table.Column<bool>(nullable: true),
                    FeedbackType = table.Column<string>(nullable: true),
                    isRevised = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "FeedbackDate", "FeedbackDescription", "FeedbackType", "FeedbackUserId", "Rate", "isRead", "isRevised" },
                values: new object[] { 1, new DateTime(2022, 10, 28, 14, 55, 29, 530, DateTimeKind.Local).AddTicks(3286), "Ez az első visszajelzés", "Visszajelzés", 1, 2.2000000000000002, false, false });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

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
