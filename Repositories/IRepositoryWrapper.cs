namespace Repository
{
    public interface IRepositoryWrapper
    {
        IChatRepository Chat { get; }
        void Save();
    }
}