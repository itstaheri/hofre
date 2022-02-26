using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AM.Infrastracture.Efcore.Migrations
{
    public partial class removea2c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleToCategories");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "articles");

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

            migrationBuilder.CreateTable(
                name: "articleTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articleTags_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryModelArticleModel_articlesId",
                table: "ArticleCategoryModelArticleModel",
                column: "articlesId");

            migrationBuilder.CreateIndex(
                name: "IX_articleTags_ArticleId",
                table: "articleTags",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategoryModelArticleModel");

            migrationBuilder.DropTable(
                name: "articleTags");

            migrationBuilder.AddColumn<long>(
                name: "ArticleCategoryId",
                table: "articles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "articleToCategories",
                columns: table => new
                {
                    ArticleCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false)
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
    }
}
