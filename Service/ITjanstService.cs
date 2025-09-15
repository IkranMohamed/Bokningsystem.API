using Bokningsystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Services
{
    public interface ITjanstService
    {
        Task<IEnumerable<Tjanst>> GetAllAsync();
        Task<Tjanst> GetAsync(int id);
        Task<Tjanst> CreateAsync(Tjanst t);
        Task UpdateAsync(Tjanst t);
        Task DeleteAsync(int id);
    }
}
