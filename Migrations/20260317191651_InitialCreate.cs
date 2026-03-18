using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOOTBALMAPSV2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalResources = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportCount = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundationYear = table.Column<int>(type: "int", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Türkiye" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Culture", "History", "LocalFood", "Name", "NaturalResources", "SupportCount" },
                values: new object[,]
                {
                    { 6, 1, "Anıtkabir, Devlet Opera ve Balesi", "Cumhuriyetin başkenti, Frigya dönemi.", "Ankara Döneri, Ankara Simidi, Beypazarı Kurusu", "Ankara", "Tuz Gölü havzası, ormanlar", 0 },
                    { 16, 1, "Ulu Cami, Koza Han", "Osmanlı Devleti'nin ilk başkenti.", "İskender Kebap, Kestane Şekeri", "Bursa", "Uludağ, kaplıcalar", 0 },
                    { 34, 1, "Kozmopolit yapı, müzeler", "Tarihi Yarımada, Bizans ve Osmanlı başkenti.", "Balık Ekmek, Kumpir, Sultanahmet Köftesi", "İstanbul", "Boğaz, ormanlar", 0 },
                    { 35, 1, "Saat Kulesi, Boyoz kültürü", "Efes Antik Kenti, İyonya uygarlığı.", "Boyoz, Kumru, Bomba, Gevrek", "İzmir", "Ege Denizi, incir, zeytin ağaçları", 0 },
                    { 61, 1, "Karadeniz kültürü, horon", "Trabzon İmparatorluğu, Sümela Manastırı.", "Akçaabat Köftesi, Kuymak, Hamsi", "Trabzon", "Uzungöl, ormanlık alanlar", 0 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CityId", "FoundationYear", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, 34, 1905, "https://upload.wikimedia.org/wikipedia/commons/f/f6/Galatasaray_Sports_Club_Logo.png", "Galatasaray" },
                    { 2, 34, 1907, "https://upload.wikimedia.org/wikipedia/tr/8/86/Fenerbah%C3%A7e_SK.png", "Fenerbahçe" },
                    { 3, 34, 1903, "https://upload.wikimedia.org/wikipedia/commons/0/08/Be%C5%9Fikta%C5%9F_Logo_Be%C5%9Fikta%C5%9F_Amblem_Be%C5%9Fikta%C5%9F_Arma.png", "Beşiktaş" },
                    { 4, 6, 1910, "https://upload.wikimedia.org/wikipedia/tr/9/91/MKE_Ankarag%C3%BCc%C3%BC.png", "MKE Ankaragücü" },
                    { 5, 6, 1923, "https://upload.wikimedia.org/wikipedia/tr/1/15/Gen%C3%A7lerbirli%C4%9Fi.png", "Gençlerbirliği" },
                    { 6, 35, 1925, "https://upload.wikimedia.org/wikipedia/tr/b/bf/G%C3%B6ztepe_Armas%C4%B1.png", "Göztepe" },
                    { 7, 16, 1963, "https://upload.wikimedia.org/wikipedia/tr/1/18/Bursaspor.png", "Bursaspor" },
                    { 8, 61, 1967, "https://upload.wikimedia.org/wikipedia/tr/a/ab/TrabzonsporAmblemi.png", "Trabzonspor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CityId",
                table: "Teams",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
