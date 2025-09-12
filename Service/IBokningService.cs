using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public interface IBokningService
    {
        Task<IEnumerable<Bokning>> GetAllAsync(int? tjanstId, string sort);
        Task<Bokning> GetAsync(int id);
        Task<Bokning> CreateAsync(Bokning b);
        Task UpdateAsync(Bokning b);
        Task DeleteAsync(int id);
    }
}
