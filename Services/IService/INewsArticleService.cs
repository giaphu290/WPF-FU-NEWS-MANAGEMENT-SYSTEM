using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface INewsArticleService
    {
        IEnumerable<NewsArticle> GetNewsArticles();
        NewsArticle GetNewsArticleByID(string id);
        void InsertNewsArticle(NewsArticle newsArticle);
        void UpdateNewsArticle(NewsArticle newsArticle);
        void DeleteNewsArticle(NewsArticle newsArticle);
        IEnumerable<NewsArticle> GetNewsArticleByAccountId(short id);
        void ChangeStatus(NewsArticle newsArticle);
        IEnumerable<NewsArticle> Report(DateTime startDate, DateTime endDate);
        IEnumerable<NewsArticle> Search(string search);
        NewsArticle GetNewsArticleWithMaxId();
        NewsArticle GetNewsArticleByCategoryId(int id);
    }
}
