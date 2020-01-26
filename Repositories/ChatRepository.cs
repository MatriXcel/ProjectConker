using ProjectConker.Models;

namespace Repository
{
    public class ChatRepository : RepositoryBase<Chat>, IChatRepository
    {
        public ChatRepository(ConkerDbContext repositoryContext)
            :base(repositoryContext)
        {
            
        }
    }
}