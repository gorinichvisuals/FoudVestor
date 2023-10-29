using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoudVestor.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToCountryTableProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Countries_country_code",
                table: "Countries",
                column: "country_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_name",
                table: "Countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_three_letter_iso_code",
                table: "Countries",
                column: "three_letter_iso_code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_country_code",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_three_letter_iso_code",
                table: "Countries");
        }
    }
}
