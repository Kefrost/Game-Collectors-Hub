using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollectorsHub.Data.Migrations
{
    public partial class AddPricesUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceUrl",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceUrl",
                table: "Games");
        }
    }
}
