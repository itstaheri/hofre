﻿// <auto-generated />
using System;
using AM.Infrastracture.Efcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AM.Infrastracture.Efcore.Migrations
{
    [DbContext(typeof(ArticleContext))]
    [Migration("20220408072429_BuildArticleComment")]
    partial class BuildArticleComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AM.Domain.ArticleAgg.ArticleModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureAlt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("AM.Domain.ArticleAgg.ArticleTagsModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("articleTags");
                });

            modelBuilder.Entity("AM.Domain.ArticleCategoryAgg.ArticleCategoryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("articleCategories");
                });

            modelBuilder.Entity("AM.Domain.ArticleCategoryAgg.ArticleToCategoryModel", b =>
                {
                    b.Property<long>("ArticleCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.HasKey("ArticleCategoryId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("articleToCategories");
                });

            modelBuilder.Entity("AM.Domain.ArticleCommentAgg.ArticleCommentModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("articleComments");
                });

            modelBuilder.Entity("AM.Domain.ArticleAgg.ArticleTagsModel", b =>
                {
                    b.HasOne("AM.Domain.ArticleAgg.ArticleModel", "article")
                        .WithMany("articleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");
                });

            modelBuilder.Entity("AM.Domain.ArticleCategoryAgg.ArticleToCategoryModel", b =>
                {
                    b.HasOne("AM.Domain.ArticleCategoryAgg.ArticleCategoryModel", "articleCategory")
                        .WithMany("articleToCategories")
                        .HasForeignKey("ArticleCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Domain.ArticleAgg.ArticleModel", "article")
                        .WithMany("articleToCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");

                    b.Navigation("articleCategory");
                });

            modelBuilder.Entity("AM.Domain.ArticleCommentAgg.ArticleCommentModel", b =>
                {
                    b.HasOne("AM.Domain.ArticleAgg.ArticleModel", "article")
                        .WithMany("articleComments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");
                });

            modelBuilder.Entity("AM.Domain.ArticleAgg.ArticleModel", b =>
                {
                    b.Navigation("articleComments");

                    b.Navigation("articleTags");

                    b.Navigation("articleToCategories");
                });

            modelBuilder.Entity("AM.Domain.ArticleCategoryAgg.ArticleCategoryModel", b =>
                {
                    b.Navigation("articleToCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
