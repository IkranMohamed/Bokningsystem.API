using Bokningsystem.API.Models;
using Bokningsystem.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public class AnvandareService : IAnvandareService
    {
        private readonly IAnvandareRepository _repo;

        public AnvandareService(IAnvandareRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Anvandare>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Anvandare> GetAsync(int id)
            => await _repo.GetAsync(id);

        public async Task<Anvandare> CreateAsync(Anvandare a)
            => await _repo.AddAsync(a);

        public async Task UpdateAsync(Anvandare a)
            => await _repo.UpdateAsync(a);

        public async Task DeleteAsync(int id)
        {
            var e = await _repo.GetAsync(id);
            if (e != null) await _repo.DeleteAsync(e);
        }
    }
}
