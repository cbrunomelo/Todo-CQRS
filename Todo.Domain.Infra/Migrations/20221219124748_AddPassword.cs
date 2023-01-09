using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Domain.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Title = table.Column<string>(type: "NVARCHAR", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR", nullable: false),
                    Done = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(2803)),
                    LastUpdate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValue: new DateTime(2022, 12, 19, 12, 47, 48, 484, DateTimeKind.Utc).AddTicks(3131))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => new { x.Title, x.Email });
                    table.ForeignKey(
                        name: "FK_Todo_User_Email",
                        column: x => x.Email,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_Email",
                table: "Todo",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
