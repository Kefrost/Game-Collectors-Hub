using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollectorsHub.Data.Migrations
{
    public partial class AddConsolesAndAmiibos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmiiboSeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmiiboSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    InitialPrice = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    PlatformId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameConsoles_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Amiibos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Franchise = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmiiboSeriesId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amiibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amiibos_AmiiboSeries_AmiiboSeriesId",
                        column: x => x.AmiiboSeriesId,
                        principalTable: "AmiiboSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amiibos_AmiiboSeriesId",
                table: "Amiibos",
                column: "AmiiboSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoles_PlatformId",
                table: "GameConsoles",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amiibos");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.DropTable(
                name: "AmiiboSeries");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "UserContent",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
