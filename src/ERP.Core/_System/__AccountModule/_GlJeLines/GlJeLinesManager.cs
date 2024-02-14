using Abp.Domain.Repositories;
using ERP._System._GlCodeComDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlJeLines
{
    public class GlJeLinesManager : IGlJeLinesManager
    {
        private readonly IRepository<GlJeLines, long> _repoGlJeLines;

        public GlJeLinesManager(
            IRepository<GlJeLines, long> repoGlJeLines)
        {
            _repoGlJeLines = repoGlJeLines;
        }

        public async Task<long> CreateListGlJeLines(List<GlJeLines> glJeLines)
        {
            foreach (var item in glJeLines)  _ = await _repoGlJeLines.InsertAsync(item);

            return 1;
        }

        public async  Task<bool> DeleteGlJeLines(long glJeHeaderId)
        {
            var data = await _repoGlJeLines.GetAll().Where(z => z.GlJeHeaderId == glJeHeaderId).ToListAsync();

            foreach (var item in data)  await _repoGlJeLines.DeleteAsync(item.Id);

            return true;
        }

        public async Task<List<GlJeLines>> GetJeLineByJeHeader(long glJeHeaderId)
        {
            var data = await _repoGlJeLines.GetAllIncluding(
                z=>z.GlCodeComDetails,
                x=>x.GlJeHeaders)
                .Where(z=>z.GlJeHeaderId == glJeHeaderId).ToListAsync();
          
            return data;
        }
    }
}
