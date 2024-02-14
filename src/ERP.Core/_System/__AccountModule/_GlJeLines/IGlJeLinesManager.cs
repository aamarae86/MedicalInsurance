using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlJeLines
{
    public interface IGlJeLinesManager:IDomainService
    {
        Task<long> CreateListGlJeLines(List<GlJeLines> glJeLines);

        Task<bool> DeleteGlJeLines(long glJeHeaderId);


        Task<List<GlJeLines>> GetJeLineByJeHeader(long glJeHeaderId);
    }
}
