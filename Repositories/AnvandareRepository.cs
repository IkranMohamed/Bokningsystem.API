using Bokningsystem.API.Models;
using Bokningsystem.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public class AnvandareRepository : GenericRepository<Anvandare>, IAnvandareRepository
    {
        public AnvandareRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<Anvandare> GetByEmailAsync(string email)
        {
            return await _ctx.Anvandare.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<Anvandare>> GetAllSortedAsync()
        {
            return await _ctx.Anvandare.OrderBy(a => a.Namn).ToListAsync();
        }
    }
}
