using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public interface IAnvandareService
    {
        Task<IEnumerable<Anvandare>> GetAllAsync();
        Task<Anvandare> GetAsync(int id);
        Task<Anvandare> CreateAsync(Anvandare a);
        Task UpdateAsync(Anvandare a);
        Task DeleteAsync(int id);
    }
}
