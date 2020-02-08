using ProjectConker.Models;

namespace Repository
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(ConkerDbContext repositoryContext)
            :base(repositoryContext)
        {
            
        }
    }
}