using Bokningsystem.API.Data; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Bokningsystem.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _ctx;

        public GenericRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<T>> GetAllAsync() => await _ctx.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => await _ctx.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}
