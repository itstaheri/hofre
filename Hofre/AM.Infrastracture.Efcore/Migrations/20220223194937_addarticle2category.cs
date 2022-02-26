using Microsoft.EntityFrameworkCore.Migrations;

namespace AM.Infrastracture.Efcore.Migrations
{
    public partial class addarticle2category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategoryModelArticleModel");

            migrationBuilder.CreateTable(
                name: "articleToCategories",
                columns: table => new
                {
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleToCategories", x => new { x.ArticleCategoryId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_articleToCategories_articleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "articleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleToCategories_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articleToCategories_ArticleId",
                table: "articleToCategories",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleToCategories");

            migrationBuilder.CreateTable(
                name: "ArticleCategoryModelArticleModel",
                columns: table => new
                {
                    articleCategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    articlesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategoryModelArticleModel", x => new { x.articleCategoriesId, x.articlesId });
                    table.ForeignKey(
                        name: "FK_ArticleCategoryModelArticleModel_articleCategories_articleCategoriesId",
                        column: x => x.articleCategoriesId,
                        principalTable: "articleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategoryModelArticleModel_articles_articlesId",
                        column: x => x.articlesId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryModelArticleModel_articlesId",
                table: "ArticleCategoryModelArticleModel",
                column: "articlesId");
        }
    }
}
