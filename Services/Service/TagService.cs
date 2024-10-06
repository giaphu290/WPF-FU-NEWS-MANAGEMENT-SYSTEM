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
    public class TagService : ITagService
    {
        private readonly ITagRepository _repo;
        public TagService(ITagRepository repo)
        {
            _repo = repo;
        }

        public List<Tag> GetAvailableTagsForArticle(string newsArticleId) => _repo.GetAvailableTagsForArticle(newsArticleId);

        public IEnumerable<Tag> GetTags() => _repo.GetTags();   
    }
}
