using BusinessObjects.Entities;
using Repositories.IRepository;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class NewsArticleService : INewsArticleService
    {
        private INewsArticleRepository _repository;
        public NewsArticleService(INewsArticleRepository repository)
        {
            _repository = repository;
        }

        public void ChangeStatus(NewsArticle newsArticle) => _repository.ChangeStatus(newsArticle);

        public void DeleteNewsArticle(NewsArticle newsArticle) => _repository.DeleteNewsArticle(newsArticle);

        public IEnumerable<NewsArticle> GetNewsArticleByAccountId(short id) => _repository.GetNewsArticleByAccountId(id);

        public NewsArticle GetNewsArticleByCategoryId(int id) => _repository.GetNewsArticleByCategoryId(id);

        public NewsArticle GetNewsArticleByID(string id)
        {
            return _repository.GetNewsArticleByID(id);
        }

        public IEnumerable<NewsArticle> GetNewsArticles()
        {
            return _repository.GetNewsArticles();
        }

        public NewsArticle GetNewsArticleWithMaxId() => _repository.GetNewsArticleWithMaxId();

        public void InsertNewsArticle(NewsArticle newsArticle)
        {
            _repository.InsertNewsArticle(newsArticle);
        }

        public IEnumerable<NewsArticle> Report(DateTime startDate, DateTime endDate) => _repository.Report(startDate, endDate);

        public IEnumerable<NewsArticle> Search(string search) => _repository.Search(search);

        public void UpdateNewsArticle(NewsArticle newsArticle)
        {
            _repository.UpdateNewsArticle(newsArticle);
        }
    }
}
