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
    public class TagManagement
    {
        private static TagManagement instance = null;
        private static readonly object instanceLock = new object();
        private TagManagement() { }
        public static TagManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TagManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Tag> GetTagList()
        {
            List<Tag> tags = new List<Tag>();
            try
            {
                var _context = new FunewsManagementFall2024Context();
                tags = _context.Tags.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tags;
        }
        public Tag GetTagById(int id)
        {
            Tag tag = null;
            try
            {
                var _context = new FunewsManagementFall2024Context();
                tag = _context.Tags.SingleOrDefault(tags => tags.TagId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tag;

        }
        public void AddNew(Tag tag)
        {
            try
            {
                Tag _tag = GetTagById(tag.TagId);
                if (_tag == null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.Tags.Add(_tag);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tag is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Tag tag)
        {
            Tag _tag = GetTagById(tag.TagId);
            try
            {
                if (_tag != null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.Entry<Tag>(tag).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tag does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public void Remove(Tag tag)
        {
            try
            {
                Tag _tag = GetTagById(tag.TagId);
                if (_tag != null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.Tags.Remove(tag);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tag does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Tag> GetAvailableTagsForArticle(string newsArticleId)
        {
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    var addedTagIds = _context.NewsArticles
                        .Where(n => n.NewsArticleId.Contains(newsArticleId))
                        .SelectMany(n => n.Tags)
                        .Select(t => t.TagId)
                        .ToList();
                    return _context.Tags
                        .Where(tag => !addedTagIds.Contains(tag.TagId))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
