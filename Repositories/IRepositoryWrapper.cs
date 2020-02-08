using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryWrapper
    {
        IChatRepository Chat { get; }
        ITagRepository Tag { get; }
        Task Save();
        void AddRange(IEnumerable<object> entities);

    }
}