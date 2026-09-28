using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Migrations
{
    /// <inheritdoc />
    public partial class SetCategoryDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categorys_CategoryId",
                table: "BlogPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categorys_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categorys_CategoryId",
                table: "BlogPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categorys_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId");
        }
    }
}
