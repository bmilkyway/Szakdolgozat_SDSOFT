using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.EntityFramework.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FeedbackDate",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedbackDescription",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedbackType",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackUserId",
                table: "Feedbacks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRead",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRevised",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FeedbackDate", "FeedbackDescription", "FeedbackType", "FeedbackUserId", "Rate", "isRead", "isRevised" },
                values: new object[] { new DateTime(2022, 10, 28, 1, 12, 45, 921, DateTimeKind.Local).AddTicks(4819), "Ez az első visszajelzés", "Visszajelzés", 1, 2.2000000000000002, false, false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 28, 1, 12, 45, 925, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 28, 1, 12, 45, 926, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 1, 12, 45, 925, DateTimeKind.Local).AddTicks(6850), new DateTime(2022, 10, 28, 1, 12, 45, 925, DateTimeKind.Local).AddTicks(6140) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackDate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackDescription",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackType",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "isRead",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "isRevised",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2022, 10, 28, 1, 11, 8, 703, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 28, 1, 11, 8, 703, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 1, 11, 8, 703, DateTimeKind.Local).AddTicks(1307), new DateTime(2022, 10, 28, 1, 11, 8, 703, DateTimeKind.Local).AddTicks(824) });
        }
    }
}
