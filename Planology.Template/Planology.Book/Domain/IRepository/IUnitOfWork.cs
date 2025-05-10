namespace Domain.IRepository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
