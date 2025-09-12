namespace Bokningsystem.API.Repositories
{
    using Bokningsystem.API.Data;
    using Bokningsystem.API.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BokningRepository : GenericRepository<Bokning>, IBokningRepository
    {
        public BokningRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Bokning>> GetFilteredAsync(int? tjanstId, string sort)
        {
            var q = _ctx.Bokningar.Include(b => b.Anvandare).Include(b => b.Tjanst).AsQueryable();

            if (tjanstId.HasValue)
                q = q.Where(b => b.TjanstId == tjanstId.Value);

            if (sort?.ToLower() == "asc")
                q = q.OrderBy(b => b.DatumTid);
            else if (sort?.ToLower() == "desc")
                q = q.OrderByDescending(b => b.DatumTid);

            return await q.ToListAsync();

        }
    }
}
