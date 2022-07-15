using AM.Application.Contract.ArticleComment;
using AM.Domain.ArticleCommentAgg;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application
{
    public class ArticleCommentApplication : IArticleCommentApplication
    {
        private readonly IArticleCommentRepository _repository;

        public ArticleCommentApplication(IArticleCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task Active(long Id)
        {
            var comment =await _repository.GetBy(Id);
            if (comment == null) throw new NotFoundException(nameof(comment), comment.Id);

            comment.Active();
            await _repository.Save();
            
        }

        public async Task Create(CreateArticleComment commend)
        {
            var comment = new ArticleCommentModel(commend.Text, commend.ArticleId, commend.UserId);
            await _repository.Create(comment);
        }

        public async Task DeActive(long Id)
        {
            var comment = await _repository.GetBy(Id);
            if (comment == null) throw new NotFoundException(nameof(comment), comment.Id);

            comment.DeActive();
            await _repository.Save();
        }

        public async Task<List<ArticleCommentViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
        }
     

    }
}
