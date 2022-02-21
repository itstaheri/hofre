using AM.Domain.ArticleCategoryAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleAgg
{
      
    public class ArticleModel :  BaseEntity
    {
        public ArticleModel(string title, string slug, string shortDescription, string description,
            string video, string picture, string pictureAlt, string pictureTitle, long articleCategoryId)
        {
            Title = title;
            Slug = slug;
            ShortDescription = shortDescription;
            Description = description;
            Video = video;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ArticleCategoryId = articleCategoryId;
        }
        public void Edit(string title, string slug, string shortDescription, string description,
            string video, string picture, string pictureAlt, string pictureTitle, long articleCategoryId)
        {
            Title = title;
            Slug = slug;
            ShortDescription = shortDescription;
            Description = description;
            Video = video;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ArticleCategoryId = articleCategoryId;

        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description {  get; private set; }
        public string Video {  get; private set; }
        public string Picture {  get; private set; }
        public string PictureAlt {  get; private set; }
        public string PictureTitle {  get; private set; }
        public long ArticleCategoryId {  get; private set; }
        public List<ArticleToCategoryModel> articleToCategories { get; private set; }

    }
}
