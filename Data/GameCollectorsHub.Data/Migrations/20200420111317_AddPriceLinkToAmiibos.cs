﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollectorsHub.Data.Migrations
{
    public partial class AddPriceLinkToAmiibos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceUrl",
                table: "Amiibos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceUrl",
                table: "Amiibos");
        }
    }
}
