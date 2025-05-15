using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatiNerde.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AppUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "AppUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
