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
    public class TagRepository : ITagRepository
    {
        public void DeleteTag(Tag tag) => TagManagement.Instance.Remove(tag);

        public List<Tag> GetAvailableTagsForArticle(string newsArticleId) => TagManagement.Instance.GetAvailableTagsForArticle(newsArticleId);

        public Tag GetTagByID(int id) => TagManagement.Instance.GetTagById(id);

        public IEnumerable<Tag> GetTags() => TagManagement.Instance.GetTagList();

        public void InsertTag(Tag tag)  => TagManagement.Instance.AddNew(tag);

        public void UpdateTag(Tag tag) => TagManagement.Instance.Update(tag);

    }
}
