using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Migrations
{
    /// <inheritdoc />
    public partial class tag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagsTagId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "Recipes",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_TagsTagId",
                table: "Recipes",
                newName: "IX_Recipes_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Recipes",
                newName: "TagsTagId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes",
                newName: "IX_Recipes_TagsTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagsTagId",
                table: "Recipes",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }
    }
}
