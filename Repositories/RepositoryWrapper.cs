using ProjectConker.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ConkerDbContext _repoContext;
        private IChatRepository _chat;
 
        public IChatRepository Chat {
            get {
                if(_chat == null)
                {
                    _chat = new ChatRepository(_repoContext);
                }
 
                return _chat;
            }
        }

        public RepositoryWrapper(ConkerDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
 
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}