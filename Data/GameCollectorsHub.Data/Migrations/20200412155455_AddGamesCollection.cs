namespace GameCollectorsHub.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGamesCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGamesCollection",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    PricePaid = table.Column<decimal>(nullable: false),
                    BoxIncluded = table.Column<bool>(nullable: false),
                    ManualIncluded = table.Column<bool>(nullable: false),
                    IsItNewAndSealed = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGamesCollection", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UserGamesCollection_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGamesCollection_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGamesCollection_GameId",
                table: "UserGamesCollection",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGamesCollection");
        }
    }
}
