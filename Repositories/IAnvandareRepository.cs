using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public interface IAnvandareRepository : IGenericRepository<Anvandare>
    {
        Task<Anvandare> GetByEmailAsync(string email);
        Task<IEnumerable<Anvandare>> GetAllSortedAsync();
    }
}
