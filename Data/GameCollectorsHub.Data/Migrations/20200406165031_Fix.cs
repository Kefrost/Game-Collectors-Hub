namespace GameCollectorsHub.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RatingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RatingId",
                table: "Comments",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
