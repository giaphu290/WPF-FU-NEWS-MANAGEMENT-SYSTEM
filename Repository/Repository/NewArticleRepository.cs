using BusinessObjects.Entities;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class NewArticleRepository : INewsArticleRepository
    {
        public void ChangeStatus(NewsArticle newsArticle) => NewsArticleManagement.Instance.ChangeStatus(newsArticle);

        public void DeleteNewsArticle(NewsArticle newsArticle) => NewsArticleManagement.Instance.Remove(newsArticle);

        public IEnumerable<NewsArticle> GetNewsArticleByAccountId(short id) => NewsArticleManagement.Instance.GetNewsArticleByAccountId(id);

        public NewsArticle GetNewsArticleByCategoryId(int id) => NewsArticleManagement.Instance.GetNewsArticleByCategoryId((short)id);

        public NewsArticle GetNewsArticleByID(string id) => NewsArticleManagement.Instance.GetNewsArticleById(id);

        public IEnumerable<NewsArticle> GetNewsArticles() => NewsArticleManagement.Instance.GetNewsArticleList();

        public NewsArticle GetNewsArticleWithMaxId() => NewsArticleManagement.Instance.GetNewsArticleWithMaxId();
        public void InsertNewsArticle(NewsArticle newsArticle) =>  NewsArticleManagement.Instance.AddNew(newsArticle);

        public IEnumerable<NewsArticle> Report(DateTime startDate, DateTime endDate) => NewsArticleManagement.Instance.Report(startDate, endDate);
        public IEnumerable<NewsArticle> Search(string search) => NewsArticleManagement.Instance.Search(search); 

        public void UpdateNewsArticle(NewsArticle newsArticle) => NewsArticleManagement.Instance.Update(newsArticle);
    }
}
