using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public interface IBokningRepository : IGenericRepository<Bokning>
    {
        Task<IEnumerable<Bokning>> GetFilteredAsync(int? tjanstId, string sort);
        Task<IEnumerable<Bokning>> GetByUserAsync(int anvandareId);   // Hämta bokningar för en viss användare
        Task<IEnumerable<Bokning>> GetByDateRangeAsync(DateTime start, DateTime end); // Hämta bokningar mellan datum

    }
}
