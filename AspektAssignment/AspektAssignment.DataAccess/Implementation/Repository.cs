using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspektAssignment.DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AspektDbContext _dbContext;

        public Repository (AspektDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id) ?? throw new KeyNotFoundException("Entity does not exist!");
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> Get()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
