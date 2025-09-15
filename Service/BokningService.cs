using Bokningsystem.API.Models;
using Bokningsystem.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public class BokningService : IBokningService
    {
        private readonly IBokningRepository _repo;

        public BokningService(IBokningRepository repo) => _repo = repo;

        public async Task<IEnumerable<Bokning>> GetAllAsync(int? tjanstId, string sort) => await _repo.GetFilteredAsync(tjanstId, sort);
        public async Task<Bokning> GetAsync(int id) => await _repo.GetAsync(id);
        public async Task<Bokning> CreateAsync(Bokning b) => await _repo.AddAsync(b);
        public async Task UpdateAsync(Bokning b) => await _repo.UpdateAsync(b);
        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetAsync(id);
            if (entity != null) await _repo.DeleteAsync(entity);
        }
    }
}
