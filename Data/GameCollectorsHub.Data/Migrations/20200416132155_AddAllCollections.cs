namespace GameCollectorsHub.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddAllCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAmiibosCollection",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    AmiiboId = table.Column<int>(nullable: false),
                    PricePaid = table.Column<decimal>(nullable: false),
                    IsItNewAndSealed = table.Column<bool>(nullable: false),
                    IsInWishlist = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAmiibosCollection", x => new { x.UserId, x.AmiiboId });
                    table.ForeignKey(
                        name: "FK_UserAmiibosCollection_Amiibos_AmiiboId",
                        column: x => x.AmiiboId,
                        principalTable: "Amiibos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAmiibosCollection_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserConsolesCollection",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GameConsoleId = table.Column<int>(nullable: false),
                    PricePaid = table.Column<decimal>(nullable: false),
                    BoxIncluded = table.Column<bool>(nullable: false),
                    IsItNewAndSealed = table.Column<bool>(nullable: false),
                    IsInWishlist = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConsolesCollection", x => new { x.UserId, x.GameConsoleId });
                    table.ForeignKey(
                        name: "FK_UserConsolesCollection_GameConsoles_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserConsolesCollection_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAmiibosCollection_AmiiboId",
                table: "UserAmiibosCollection",
                column: "AmiiboId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConsolesCollection_GameConsoleId",
                table: "UserConsolesCollection",
                column: "GameConsoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAmiibosCollection");

            migrationBuilder.DropTable(
                name: "UserConsolesCollection");
        }
    }
}
