using BusinessObjects.Entities;
using DataAccessObjects.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class NewsArticleManagement
    {
        private static NewsArticleManagement instance = null;
        private static readonly object instanceLock = new object();
        private NewsArticleManagement() { }
        public static NewsArticleManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsArticleManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<NewsArticle> GetNewsArticleList()
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    newsArticles = _context.NewsArticles
                        .Include(x => x.Tags)
                        .Include(y => y.Category)
                        .Where(newsArticle => newsArticle.NewsStatus == true)
                        .OrderByDescending(newsArticle => newsArticle.CreatedDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;
        }
        public NewsArticle GetNewsArticleById(string id)
        {
            NewsArticle newsArticles = null;
            try
            {
                var _context = new FunewsManagementFall2024Context();
                newsArticles = _context.NewsArticles.SingleOrDefault(newsArticles => newsArticles.NewsArticleId.Contains(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;


        }
        public NewsArticle GetNewsArticleByCategoryId(int id)
        {
            NewsArticle newsArticles = null;
            try
            {
                var _context = new FunewsManagementFall2024Context();
                newsArticles = _context.NewsArticles.SingleOrDefault(newsArticles => newsArticles.CategoryId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;

        }
        public IEnumerable<NewsArticle> GetNewsArticleByAccountId(short id)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    newsArticles = _context.NewsArticles
                        .Include(x => x.Category)
                        .Where(newsArticle => newsArticle.CreatedById == id)
                        .OrderByDescending(newsArticle => newsArticle.CreatedDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;
        }
        public void AddNew(NewsArticle newsArticles)
        {
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    foreach (var tag in newsArticles.Tags)
                    {
                        _context.Tags.Attach(tag);
                    }
                    _context.NewsArticles.Add(newsArticles);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    var existingArticle = _context.NewsArticles
                        .Include(na => na.Tags)
                        .FirstOrDefault(na => na.NewsArticleId == newsArticle.NewsArticleId);
                    if (existingArticle == null) throw new Exception("News article does not exist.");
                    _context.Entry(existingArticle).CurrentValues.SetValues(newsArticle);
                    existingArticle.Tags.Clear();
                    foreach (var updatedTag in newsArticle.Tags)
                    {
                        var existingTag = _context.Tags.Find(updatedTag.TagId);
                        if (existingTag != null) existingArticle.Tags.Add(existingTag);
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public void Remove(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    var _newsArticle = _context.NewsArticles.Include(na => na.Tags)
                                                            .FirstOrDefault(na => na.NewsArticleId == newsArticle.NewsArticleId);
                    if (_newsArticle != null)
                    {
                        _newsArticle.Tags.Clear();
                        _context.NewsArticles.Remove(_newsArticle);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("News article does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangeStatus(NewsArticle newsArticle)
        {
            try
            {
                var _context = new FunewsManagementFall2024Context();
                var a = _context.NewsArticles!.FirstOrDefault(c => c.NewsArticleId.Equals(newsArticle.NewsArticleId));


                if (a == null)
                {
                    throw new Exception("News Article does not already exist.");
                }
                else
                {
                    a.NewsStatus = false;
                    _context.Entry(a).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NewsArticle GetNewsArticleWithMaxId()
        {
            NewsArticle newsArticle = null;
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    newsArticle = _context.NewsArticles
                        .OrderByDescending(n => n.NewsArticleId)
                        .First();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return newsArticle;
        }
        public IEnumerable<NewsArticle> Search(string search)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    newsArticles = _context.NewsArticles
                        .Include(x => x.Category)
                        .Where(newsArticle => newsArticle.NewsTitle.ToLower().Contains(search.ToLower()) && newsArticle.NewsStatus == true)
                        .OrderByDescending(newsArticle => newsArticle.CreatedDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;
        }
        public IEnumerable<NewsArticle> Report(DateTime startDate, DateTime endDate)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    newsArticles = _context.NewsArticles
                        .Include(x => x.Category)
                        .Where(newsArticle => newsArticle.CreatedDate >= startDate &&
                                            newsArticle.CreatedDate <= endDate &&
                                                newsArticle.NewsStatus == true)
                        .OrderByDescending(newsArticle => newsArticle.CreatedDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsArticles;

        }
    }
}

