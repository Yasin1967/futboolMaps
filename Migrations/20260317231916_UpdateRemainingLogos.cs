using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOOTBALMAPSV2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRemainingLogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "/images/teams/Fenerbahçe_SK.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                column: "LogoUrl",
                value: "/images/teams/Genclerbirligi.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/tr/8/86/Fenerbah%C3%A7e_SK.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/tr/1/15/Gen%C3%A7lerbirli%C4%9Fi.png");
        }
    }
}
