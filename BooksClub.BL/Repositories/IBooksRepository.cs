using BooksClub.DAL.Models;

namespace BooksClub.BL.Repositories
{
    public interface IBooksRepository : IRepository<ModelBooks>
    {
    }
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IReadOnlyCollection<T>> Get();
        Task Update(T entity);
        Task Delete(int Id);
    }
}
