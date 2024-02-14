using Abp.Application.Services.Dto;
using ERP._System.__ReportsPms.Dto;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using ERP._System.__ReportsPms.Proc;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__ReportsPms
{
    [Abp.Authorization.AbpAuthorize]
    public class ReportsPmsAppService : ERPAppServiceBase, IReportsPmsAppService
    {
        private readonly IPmPropertiesUnitsUnoccupiedRepository _pmPropertiesUnitsUnoccupiedRepository;
        private readonly IPmContractNotRenewedRepository _pmContractNotRenewedRepository;
        private readonly IPmContractsRepository _pmContractsRepository;
        private readonly IGetrptArDebitCreditRepository _getrptArDebitCreditRepository;
        private readonly IGetrptPmPropertiesIncomeRepository _getrptPmPropertiesIncomeRepository;

        public ReportsPmsAppService(IPmPropertiesUnitsUnoccupiedRepository pmPropertiesUnitsUnoccupiedRepository
            , IPmContractNotRenewedRepository pmContractNotRenewedRepository
            , IPmContractsRepository pmContractsRepository
            , IGetrptArDebitCreditRepository getrptArDebitCreditRepository
            , IGetrptPmPropertiesIncomeRepository getrptPmPropertiesIncomeRepository)
        {
            _getrptArDebitCreditRepository = getrptArDebitCreditRepository;
            _pmPropertiesUnitsUnoccupiedRepository = pmPropertiesUnitsUnoccupiedRepository;
            _pmContractNotRenewedRepository = pmContractNotRenewedRepository;
            _pmContractsRepository = pmContractsRepository;
            _getrptPmPropertiesIncomeRepository = getrptPmPropertiesIncomeRepository;
        }

        public async Task<List<PmPropertiesUnitsUnoccupiedOutput>> GetPmPropertiesUnitsUnoccupied(PmPropertiesUnitsUnoccupiedInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var result = await _pmPropertiesUnitsUnoccupiedRepository.Execute(input, "GetPmPropertiesUnitsUnoccupied");

            return result.ToList<PmPropertiesUnitsUnoccupiedOutput>();
        }

        public async Task<List<rptPmPropertiesIncomeOutput>> GetrptPmPropertiesIncome(rptPmPropertiesIncomeHelperInput helperInput)
        {
            try
            {
                helperInput.TenantId = AbpSession.TenantId.Value;

                var input = ObjectMapper.Map<rptPmPropertiesIncomeInput>(helperInput);

                var result = await _getrptPmPropertiesIncomeRepository.Execute(input, "rptPmPropertiesIncome");

                return result.ToList<rptPmPropertiesIncomeOutput>();
            }
            catch (System.Exception x)
            {

                throw;
            }
        }

        public async Task<List<PmContractNotRenewedOutput>> GetPmContractNotRenewed(PmContractNotRenewedInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var result = await _pmContractNotRenewedRepository.Execute(input, "GetPmContractNotRenewed");

            return result.ToList<PmContractNotRenewedOutput>();
        }

        public async Task<List<PmContractsOutput>> GetPmContracts(PmContractsHelperInput helperInput)
        {
            helperInput.TenantId = AbpSession.TenantId.Value;

            var input = ObjectMapper.Map<PmContractsInput>(helperInput);

            var result = await _pmContractsRepository.Execute(input, "GetPmContracts");

            return result.ToList<PmContractsOutput>();
        }

        public async Task<List<rptArDebitCreditOutput>> GetrptArDebitCredit(rptArDebitCreditInputHelper inputHelper)
        {
            inputHelper.TenantId = AbpSession.TenantId.Value;

            var input = ObjectMapper.Map<rptArDebitCreditInput>(inputHelper);

            var result = await _getrptArDebitCreditRepository.Execute(input, "rptArDebitCredit");

            return result.ToList<rptArDebitCreditOutput>();
        }


        public async Task<PagedResultDto<rptArDebitCreditOutputDto>> GetTenantAccountGrid(rptArDebitCreditInputPaged input)
        {
            try
            {
                var map = ObjectMapper.Map<rptArDebitCreditInput>(input.Params);
                map.TenantId= AbpSession.TenantId.Value;
                var result = await _getrptArDebitCreditRepository.Execute(map, "rptArDebitCredit");
                var data2 = ObjectMapper.Map(result, new List<rptArDebitCreditOutputDto>());
                var count = data2.Count();
                var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };


                List<rptArDebitCreditOutputDto> items = new List<rptArDebitCreditOutputDto>();
                decimal cBalance = 0;
                foreach (var item in data2)
                {
                    rptArDebitCreditOutputDto obj = new rptArDebitCreditOutputDto()
                    {
                        DocDate = item.DocDate,
                        Address = item.Address,
                        Comments = item.Comments,
                        CrAmount = item.CrAmount,
                        DrAmount = item.DrAmount,
                        Fax = item.Fax,
                        Source = item.Source,
                        tel = item.tel,
                        CustomerNumber=item.CustomerNumber,
                        CustomerNameAr=item.CustomerNameAr,
                        ArCustomerId=item.ArCustomerId,
                        Balance = cBalance + item.DrAmount - item.CrAmount,



                    };
                    cBalance = obj.Balance;
                    items.Add(obj);
                }



                //data2 = data2.DynamicOrderBy(listOrder);
                items = items.Skip(input.SkipCount).ToList();
                var PagedResultDto = new PagedResultDto<rptArDebitCreditOutputDto>()
                {
                    Items = items as IReadOnlyList<rptArDebitCreditOutputDto>,
                    TotalCount = count
                };
                return PagedResultDto;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
