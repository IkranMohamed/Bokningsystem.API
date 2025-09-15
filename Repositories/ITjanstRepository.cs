using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public interface ITjanstRepository : IGenericRepository<Tjanst>
    {
        Task<Tjanst> GetByNameAsync(string name);
        Task<IEnumerable<Tjanst>> GetAllSortedAsync();
    }
}
