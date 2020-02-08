using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectConker.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ConkerDbContext _repoContext;
        private IChatRepository _chat;

        private ITagRepository _tag;
 
        public IChatRepository Chat {
            get {
                if(_chat == null)
                {
                    _chat = new ChatRepository(_repoContext);
                }
 
                return _chat;
            }
        }

        public ITagRepository Tag {
            get {
                if(_tag == null)
                {
                    _tag = new TagRepository(_repoContext);
                }
 
                return _tag;
            }
        }

        public RepositoryWrapper(ConkerDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void AddRange(IEnumerable<object> entities)
        {
            _repoContext.AddRange(entities);
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}