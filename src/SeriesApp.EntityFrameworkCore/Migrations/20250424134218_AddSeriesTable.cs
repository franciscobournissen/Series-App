using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSeriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingImdb",
                table: "AppSeries",
                newName: "ImdbRating");

            migrationBuilder.RenameColumn(
                name: "CountryOrigin",
                table: "AppSeries",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImdbRating",
                table: "AppSeries",
                newName: "RatingImdb");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AppSeries",
                newName: "CountryOrigin");
        }
    }
}
