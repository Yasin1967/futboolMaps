using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOOTBALMAPSV2.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achievements",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Achievements", "History" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achievements",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Teams");
        }
    }
}
