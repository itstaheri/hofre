using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleCategoryAgg
{
    public class ArticleCategoryModel : BaseEntity
    {
        public ArticleCategoryModel(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }

        public string Name {  get; private set; }
        public List<ArticleToCategoryModel>  articleToCategories { get; private set; }

    }
}
