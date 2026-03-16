using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapStone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DescNFeaturesToPolicyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PolicyTypes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "PolicyTypes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PolicyTypes");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "PolicyTypes");
        }
    }
}
