using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Migrations
{
    /// <inheritdoc />
    public partial class AddingTagsToRecipeController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagsTagId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TagsTagId",
                table: "Recipes",
                column: "TagsTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagsTagId",
                table: "Recipes",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagsTagId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_TagsTagId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TagsTagId",
                table: "Recipes");
        }
    }
}
