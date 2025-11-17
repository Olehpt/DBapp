using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBapp.Migrations
{
    /// <inheritdoc />
    public partial class IndexOnPriceAtribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitPrice",
                table: "Products",
                column: "UnitPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_UnitPrice",
                table: "Products");
        }
    }
}
