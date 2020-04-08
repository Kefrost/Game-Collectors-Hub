using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollectorsHub.Data.Migrations
{
    public partial class EditAmiiboAndConsolePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InitialPrice",
                table: "GameConsoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Amiibos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Amiibos");

            migrationBuilder.AlterColumn<int>(
                name: "InitialPrice",
                table: "GameConsoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
