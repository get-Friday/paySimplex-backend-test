using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paySimplex.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CHORES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    STATUS = table.Column<int>(type: "INT", nullable: false),
                    FILE = table.Column<byte[]>(type: "VARBINARY", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CHORES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHORES_UserId",
                table: "CHORES",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHORES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
