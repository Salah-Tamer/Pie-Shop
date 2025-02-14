using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieShop.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdressLine2",
                table: "Orders",
                newName: "Governorate");

            migrationBuilder.RenameColumn(
                name: "AdressLine1",
                table: "Orders",
                newName: "AddressLine1");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Governorate",
                table: "Orders",
                newName: "AdressLine2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Orders",
                newName: "AdressLine1");
        }
    }
}
