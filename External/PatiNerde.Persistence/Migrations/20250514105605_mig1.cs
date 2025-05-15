using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatiNerde.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppMapMakers",
                columns: table => new
                {
                    MapMakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateByUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Enlem = table.Column<float>(type: "real", nullable: false),
                    Boylam = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMapMakers", x => x.MapMakerId);
                    table.ForeignKey(
                        name: "FK_AppMapMakers_AppUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMapMakers_CreateByUserId",
                table: "AppMapMakers",
                column: "CreateByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMapMakers");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
