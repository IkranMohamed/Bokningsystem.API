using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public interface IBokningRepository : IGenericRepository<Bokning>
    {
        Task<IEnumerable<Bokning>> GetFilteredAsync(int? tjanstId, string sort);
    }
}
