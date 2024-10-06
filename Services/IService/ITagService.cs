using BusinessObjects.Entities;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
        List<Tag> GetAvailableTagsForArticle(string newsArticleId);

    }
}
