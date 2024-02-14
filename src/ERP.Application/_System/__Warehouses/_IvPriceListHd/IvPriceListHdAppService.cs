using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvPriceListHd.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvPriceListHd
{
    [AbpAuthorize]
    public class IvPriceListHdAppService : AsyncCrudAppService<IvPriceListHd, IvPriceListHdDto, long, IvPriceListHdPagedDto, IvPriceListHdCreateDto, IvPriceListHdEditDto>, IIvPriceListHdAppService
    {
        private readonly IRepository<IvPriceListTr, long> _repoIvPriceListTr;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<IvItems, long> _repoIvItems;

        private readonly IIvItemsAppService _ivItemsService;


        public IvPriceListHdAppService(IRepository<IvPriceListHd, long> repository,
          IRepository<IvPriceListTr, long> repoIvPriceListTr, IRepository<IvItems, long> repoIvItems,
          IGetCounterRepository getCounterRepository, IIvItemsAppService ivItemsService) : base(repository)
        {
            _repoIvPriceListTr = repoIvPriceListTr;
            _repoProcCounter = getCounterRepository;
            _ivItemsService = ivItemsService;
            _repoIvItems = repoIvItems;

            CreatePermissionName = PermissionNames.Pages_IvPriceListHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvPriceListHd_Update;
            DeletePermissionName = PermissionNames.Pages_IvPriceListHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvPriceListHd;
        }

       

    protected override IQueryable<IvPriceListHd> CreateFilteredQuery(IvPriceListHdPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PriceListNumber))
                iqueryable = iqueryable.Where(z => z.PriceListNumber.Contains(input.Params.PriceListNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PriceListName))
                iqueryable = iqueryable.Where(z => z.PriceListName.Contains(input.Params.PriceListName));

            return iqueryable;
        }

        public async Task<List<IvPriceListTrDto>> GetAllPriceListDetails(EntityDto<long> input)
        {
            var listData = await _repoIvPriceListTr.GetAllIncluding(x => x.IvItems)
                               .Where(d => d.IvPriceListHdId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<IvPriceListTrDto>>(listData);
        }

        public async override Task<IvPriceListHdDto> Create(IvPriceListHdCreateDto input)
        {
            CheckCreatePermission();
            input.PriceListNumber = await GetPriceListNumber();
            var IvPriceList = ObjectMapper.Map<IvPriceListHd>(input);

            _ = await Repository.InsertAsync(IvPriceList);

            if (input.PriceListDetails != null && input.PriceListDetails.Count > 0)
                foreach (var item in input.PriceListDetails)
                    await InsertIvPriceListData(item, IvPriceList.Id);

            return new IvPriceListHdDto { };
        }

        private async Task InsertIvPriceListData(IvPriceListTrDto PriceListTrDto, long masterId)
        {
            PriceListTrDto.IvPriceListHdId = masterId;

            var PriceListTr = ObjectMapper.Map<IvPriceListTr>(PriceListTrDto);

            if(PriceListTr != null)
                PriceListTr.IvItems = null;

            _ = await _repoIvPriceListTr.InsertAsync(PriceListTr);
        }

        private async Task CRUD_IvPriceList(ICollection<IvPriceListTrDto> PriceListTrDtos, long masterId)
        {
            try
            {
                if (PriceListTrDtos != null && PriceListTrDtos.Count > 0)
                {
                    foreach (var item in PriceListTrDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var PriceListTr = await _repoIvPriceListTr.GetAsync((long)item.Id);

                            item.IvPriceListHdId = masterId;

                            ObjectMapper.Map(item, PriceListTr);
                            if (PriceListTr != null)
                                PriceListTr.IvItems = null;
                            _ = await _repoIvPriceListTr.UpdateAsync(PriceListTr);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertIvPriceListData(item, masterId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoIvPriceListTr.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var s = ex;
            }
        }

        public async override Task<IvPriceListHdDto> Update(IvPriceListHdEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            await CRUD_IvPriceList(input.PriceListDetails, input.Id);

            return new IvPriceListHdDto { };
        }

        public async Task<List<IvPriceListTrDto>> GetSalesPriceData(bool AllOrganizationcheck, decimal percentage, long IvItemsTypesConfigureId)
        {
             
            List<IvPriceListTrDto> list = new List<IvPriceListTrDto>();

                var iqueryable = _repoIvItems.GetAllIncluding(z => z.IvItemsTypesConfigure);
                if (AllOrganizationcheck != false)
                {
                }
                else
                {
                    if (IvItemsTypesConfigureId != 0)
                    {
                        iqueryable = iqueryable.Where(z => z.IvItemsTypesConfigureId == IvItemsTypesConfigureId);
                    }
                }
                foreach (var s in iqueryable)
                {
                    
                    var newprice = s.AvgCost + (s.AvgCost * percentage / 100) ==null ? 0 : s.AvgCost + (s.AvgCost * percentage / 100);
                  
                        var ivPriceListTr = new IvPriceListTrDto()
                    {
                        Price = newprice.Value,
                        IvItemId = s.Id,
                        ItemName=s.ItemName
                        
                        
                    };
                    list.Add(ivPriceListTr);
                }
            return list;
        }

        private async Task<string> GetPriceListNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvPriceListHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            //return await _moduleManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);
            var data = Repository.GetAll();
            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel
                        {
                            id = z.Id,
                            text = z.PriceListName
                        })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<IvPriceListHdDto> GetDetailAsync(EntityDto<long> input)
           => ObjectMapper.Map<IvPriceListHdDto>(await Repository.GetAll()
                          .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

    }
}
