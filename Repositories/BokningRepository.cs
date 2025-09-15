using Bokningsystem.API.Data;
using Bokningsystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokningsystem.API.Repositories
{
    public class BokningRepository : GenericRepository<Bokning>, IBokningRepository
    {
        public BokningRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Bokning>> GetFilteredAsync(int? tjanstId, string sort)
        {
            var q = _ctx.Bokningar
                .Include(b => b.Anvandare)
                .Include(b => b.Tjanst)
                .AsQueryable();

            if (tjanstId.HasValue)
                q = q.Where(b => b.TjanstId == tjanstId.Value);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.ToLower() == "asc")
                    q = q.OrderBy(b => b.DatumTid);
                else if (sort.ToLower() == "desc")
                    q = q.OrderByDescending(b => b.DatumTid);
            }

            return await q.ToListAsync();
        }

        public async Task<IEnumerable<Bokning>> GetByUserAsync(int anvandareId)
        {
            return await _ctx.Bokningar
                .Include(b => b.Anvandare)
                .Include(b => b.Tjanst)
                .Where(b => b.AnvandareId == anvandareId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bokning>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _ctx.Bokningar
                .Include(b => b.Anvandare)
                .Include(b => b.Tjanst)
                .Where(b => b.DatumTid >= start && b.DatumTid <= end)
                .ToListAsync();
        }
    }
}
