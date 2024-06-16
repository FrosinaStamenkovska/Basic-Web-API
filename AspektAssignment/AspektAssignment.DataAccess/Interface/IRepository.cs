using AspektAssignment.Domain;

namespace AspektAssignment.DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task <List<T>> Get();
        Task <T> GetById(int id);
        Task <int> Create(T entity);
        Task <T> Update(T entity);
        Task Delete(int id);
    }
}
