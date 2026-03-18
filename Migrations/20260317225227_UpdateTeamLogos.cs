using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOOTBALMAPSV2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamLogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "/images/teams/Galatasaray_Sports_Club_Logo.svg.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "/images/teams/BesiktasJK-Logo.svg.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoUrl",
                value: "/images/teams/MKE_Ankaragücü_logo.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                column: "LogoUrl",
                value: "/images/teams/330px-Bursaspor-amblem.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                column: "LogoUrl",
                value: "/images/teams/TrabzonsporAmblemi.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/f/f6/Galatasaray_Sports_Club_Logo.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/0/08/Be%C5%9Fikta%C5%9F_Logo_Be%C5%9Fikta%C5%9F_Amblem_Be%C5%9Fikta%C5%9F_Arma.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/tr/9/91/MKE_Ankarag%C3%BCc%C3%BC.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/tr/1/18/Bursaspor.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/tr/a/ab/TrabzonsporAmblemi.png");
        }
    }
}
