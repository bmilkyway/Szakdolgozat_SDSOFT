using Microsoft.EntityFrameworkCore.Migrations;

using MySql.Data.EntityFrameworkCore.Metadata;

namespace CRM.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PermissionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LoginDate = table.Column<DateTime>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ToUserId = table.Column<int>(nullable: false),
                    FromUserId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    isRead = table.Column<bool>(nullable: false),
                    MessageText = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TaskName = table.Column<string>(nullable: false),
                    TaskDescription = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<int>(nullable: false),
                    TaskStatusId = table.Column<int>(nullable: false),
                    ResponsibleUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "FromUserId", "MessageText", "SendDate", "Subject", "ToUserId", "UserId", "isRead" },
                values: new object[] { 1, 1, "Ez az első elküldött levél", new DateTime(2022, 8, 29, 18, 11, 10, 48, DateTimeKind.Local).AddTicks(603), "Első levél", 1, false });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionName" },
                values: new object[,]
                {
                    { 2, "Tulajdonos" },
                    { 3, "Irodai munkatárs" },
                    { 4, "Külsős" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Tervezés alatt" },
                    { 2, "Szabad" },
                    { 3, "Elvállalt" },
                    { 4, "Lezárt" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Category", "CloseDate", "CreateDate", "CreatedUserId", "DeadLine", "ResponsibleUserId", "TaskDescription", "TaskName", "TaskStatusId", "UserId" },
                values: new object[] { 1, "Prgramozás", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 29, 18, 11, 10, 48, DateTimeKind.Local).AddTicks(4889), 1, new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ez az első feladat leírása", "Első feladat", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "LoginDate", "Name", "Password", "PermissionId", "RegistrationDate", "UserName" },
                values: new object[] { 1, "Bajarmilan2001@gmail.com", true, new DateTime(2022, 8, 29, 18, 11, 10, 46, DateTimeKind.Local).AddTicks(6765), "Bajár Milán", "Admin", 1, new DateTime(2022, 8, 29, 18, 11, 10, 43, DateTimeKind.Local).AddTicks(7261), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
