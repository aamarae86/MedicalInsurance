using ERP._System.__ReportsTms.Inputs;
using ERP._System.__ReportsTms.Outputs;
using ERP._System.__ReportsTms.Proc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__ReportsTms
{
    [Abp.Authorization.AbpAuthorize]
    public class TmCharityBoxListAppService : ERPAppServiceBase, ITmCharityBoxListAppService
    {
        private readonly ITmCharityBoxListScreenDataRepository _tmCharityBoxListScreenDataRepository;
        public TmCharityBoxListAppService(ITmCharityBoxListScreenDataRepository tmCharityBoxListScreenDataRepository)
        {
            _tmCharityBoxListScreenDataRepository = tmCharityBoxListScreenDataRepository;
        }
        public async Task<List<TmCharityBoxListScreenDataOutput>> GetTmCharityBoxListScreenData(TmCharityBoxListScreenDataInput input)
        {

            var result = await _tmCharityBoxListScreenDataRepository.Execute(input, "GetTmCharityBoxListScreenData");

            return result.ToList<TmCharityBoxListScreenDataOutput>();
        }
    }
}
