using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Domain.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(826),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(557),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "NVARCHAR", nullable: false),
                    UserEmail = table.Column<string>(type: "NVARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleName, x.UserEmail });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Role",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserEmail",
                table: "UserRole",
                column: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(3131),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(2803),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(557));
        }
    }
}
