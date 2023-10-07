using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalmonCookies.Migrations
{
    /// <inheritdoc />
    public partial class addEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cookiestands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minimum_customers_per_hour = table.Column<int>(type: "int", nullable: false),
                    maximum_customers_per_hour = table.Column<int>(type: "int", nullable: false),
                    average_cookies_per_sale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookiestands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HourlySales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookieStandsId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlySales_Cookiestands_CookieStandsId",
                        column: x => x.CookieStandsId,
                        principalTable: "Cookiestands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlySales_CookieStandsId",
                table: "HourlySales",
                column: "CookieStandsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlySales");

            migrationBuilder.DropTable(
                name: "Cookiestands");
        }
    }
}
