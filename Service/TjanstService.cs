using Bokningsystem.API.Models;
using Bokningsystem.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public class TjanstService : ITjanstService
    {
        private readonly ITjanstRepository _repo;

        public TjanstService(ITjanstRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Tjanst>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Tjanst> GetAsync(int id)
            => await _repo.GetAsync(id);

        public async Task<Tjanst> CreateAsync(Tjanst t)
            => await _repo.AddAsync(t);

        public async Task UpdateAsync(Tjanst t)
            => await _repo.UpdateAsync(t);

        public async Task DeleteAsync(int id)
        {
            var e = await _repo.GetAsync(id);
            if (e != null) await _repo.DeleteAsync(e);
        }
    }
}
