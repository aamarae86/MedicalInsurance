using ERP._System.__ReportsSales.Input;
using ERP._System.__ReportsSales.Output;
using ERP._System.__ReportsSales.Proc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__ReportsSales
{
    [Abp.Authorization.AbpAuthorize]
    public class ReportsSalesAppService : ERPAppServiceBase, IReportsSalesAppService
    {
     
        private readonly IGetrptArJobCardRepository _getrptArJobCardRepository;
        private readonly IGetrptArJobCardDetailsRepository _getrptArJobCardDetailsRepository;

        public ReportsSalesAppService(IGetrptArJobCardRepository getrptArJobCardRepository,
                                      IGetrptArJobCardDetailsRepository getrptArJobCardDetailsRepository
                                     )
        {
            _getrptArJobCardRepository = getrptArJobCardRepository;
            _getrptArJobCardDetailsRepository = getrptArJobCardDetailsRepository;
        }


        public async Task<List<ArJobCardOutput>> GetArJobCards(ArJobCardHelperInput inputHelper)
        {
            try
            {
                inputHelper.TenantId = AbpSession.TenantId.Value;

                var input = ObjectMapper.Map<ArJobCardInput>(inputHelper);

                var result = await _getrptArJobCardRepository.Execute(input, "rptArJobCard");

                return result.ToList<ArJobCardOutput>();
            }
            catch (Exception ex)
            {

                throw;
            }
                
        }


        public async Task<List<ArJobCardDetailsOutput>> GetArJobCardsDetails(ArJobCardDetailsHelperInput inputHelper)
        {
            try
            {
                inputHelper.TenantId = AbpSession.TenantId.Value;

                var input = ObjectMapper.Map<ArJobCardDetailsInput>(inputHelper);

                var result = await _getrptArJobCardDetailsRepository.Execute(input, "rptArJobCardDetails");

                return result.ToList<ArJobCardDetailsOutput>();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
