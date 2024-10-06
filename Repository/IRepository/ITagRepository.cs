using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTags();
        Tag GetTagByID(int id);
        void InsertTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
        List<Tag> GetAvailableTagsForArticle(string newsArticleId);

    }
}
