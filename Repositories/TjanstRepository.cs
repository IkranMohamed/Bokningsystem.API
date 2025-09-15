using Bokningsystem.API.Models;
using Bokningsystem.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public class TjanstRepository : GenericRepository<Tjanst>, ITjanstRepository
    {
        public TjanstRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<Tjanst> GetByNameAsync(string name)
        {
            return await _ctx.Tjanster.FirstOrDefaultAsync(t => t.Namn == name);
        }

        public async Task<IEnumerable<Tjanst>> GetAllSortedAsync()
        {
            return await _ctx.Tjanster.OrderBy(t => t.Namn).ToListAsync();
        }
    }
}
