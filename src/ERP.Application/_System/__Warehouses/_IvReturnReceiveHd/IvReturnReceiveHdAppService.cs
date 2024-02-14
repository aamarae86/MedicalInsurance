using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses.__IvInventorySetting.Dto;
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
using ERP._System.__Warehouses._IvInventorySetting;
using ERP.Authorization.Users;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP.Core.Helpers.Extensions;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__SalesModule._IvReturnSaleHd.Proc;
using ERP._System.__Warehouses._IvReturnReceiveHd.Dto;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__Warehouses._IvReturnReceiveHd.Proc;

namespace ERP._System.__Warehouses._IvReturnReceiveHd
{
    [AbpAuthorize]
   public class IvReturnReceiveHdAppService : AsyncCrudAppService<IvReturnReceiveHd, IvReturnReceiveHdDto, long, IvReturnReceiveHdPagedDto, IvReturnReceiveHdCreateDto, IvReturnReceiveHdEditDto>, IIvReturnReceiveHdAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<IvReturnReceiveTr, long> _repoIvReturnReceiveTr;
        private readonly IRepository<IvReceiveTr, long> _repoIvReceiveTr;
        private readonly IRepository<IvReceiveHd, long> _repoIvReceiveHd;
        private readonly IRepository<IvItems, long> _repoIvItems;
        private readonly IIvReturnReceiveHdPostRepository _ivReturnReceiveHdPostRepository;


        public IvReturnReceiveHdAppService(IRepository<IvReturnReceiveHd, long> repository,
             IRepository<IvReturnReceiveTr, long> repoIvReturnReceiveTr,
             IRepository<IvReceiveTr, long> repoIvReceiveTr,
             IRepository<IvReceiveHd, long> repoIvReceiveHd,
             IRepository<IvItems, long> repoIvItems,
             IIvReturnReceiveHdPostRepository ivReturnReceiveHdPostRepository,
             IGetCounterRepository getCounterRepository
             
             ) : base(repository)
        {

            _repoProcCounter = getCounterRepository;
            _repoIvReturnReceiveTr = repoIvReturnReceiveTr;
            _repoIvReceiveTr = repoIvReceiveTr;
            _repoIvReceiveHd = repoIvReceiveHd;
            _repoIvItems = repoIvItems;
            _ivReturnReceiveHdPostRepository = ivReturnReceiveHdPostRepository;


             CreatePermissionName = PermissionNames.Pages_IvReturnReceiveHd_Insert;
            GetAllPermissionName = PermissionNames.Pages_IvReturnReceiveHd;
        }


        public override async Task<PagedResultDto<IvReturnReceiveHdDto>> GetAll(IvReturnReceiveHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.IvReceiveHd, x => x.Currency, x => x.FndLookupStatusLkp, x => x.IvReturnReceiveTrs, x => x.IvReceiveHd.ApVendors, x => x.IvReceiveHd.IvWarehouses,x=>x.IvReceiveHd);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvReturnReceiveNumber))
                iqueryable = iqueryable.Where(z => z.IvReturnReceiveNumber.Contains(input.Params.IvReturnReceiveNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvReturnReceiveDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.IvReturnReceiveDate.ToString());
                iqueryable = iqueryable.Where(z => z.IvReturnReceiveDate == dt);
            }
            if (input.Params != null && input.Params.IvReceiveHdId != 0)
                iqueryable = iqueryable.Where(z => z.IvReceiveHdId == input.Params.IvReceiveHdId);


            if (input.Params != null && input.Params.StatusLkpId != 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);


            var count = await iqueryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            iqueryable = iqueryable.DynamicOrderBy(listOrder);
            iqueryable = iqueryable.Skip(input.SkipCount);
            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<IvReturnReceiveHdDto>());
            foreach (var item in data2)
            {
                //(Qty*unitprice)+taxamount
                item.Amount = item.IvReturnReceivedetails?.Sum(x => (x.RQty * x.UnitPrice + x.TaxAmount)) ?? 0;
            }
            var PagedResultDto = new PagedResultDto<IvReturnReceiveHdDto>()
            {
                Items = data2 as IReadOnlyList<IvReturnReceiveHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }
        public override async Task<IvReturnReceiveHdDto> Create(IvReturnReceiveHdCreateDto input)
        {
            try
            {
                CheckCreatePermission();
                input.IvReturnReceiveNumber = await GetReturnreceiveNumber();
                var IvReturnReceiveHdList = ObjectMapper.Map<IvReturnReceiveHd>(input);

                _ = await Repository.InsertAsync(IvReturnReceiveHdList);


                if (input.IvReturnReceivedetails != null && input.IvReturnReceivedetails.Count > 0)
                    foreach (var item in input.IvReturnReceivedetails)
                        await InsertReturnReceiveListData(item, IvReturnReceiveHdList.Id);

                return new IvReturnReceiveHdDto { };

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private async Task InsertReturnReceiveListData(IvReturnReceiveTrDto IvReturnReceiveTrListDto, long masterId)
        {
            try
            {
                IvReturnReceiveTrListDto.IvReturnReceiveHdId = masterId;
                var IvReturnReceiveList = ObjectMapper.Map<IvReturnReceiveTr>(IvReturnReceiveTrListDto);

                _ = await _repoIvReturnReceiveTr.InsertAsync(IvReturnReceiveList);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IvReturnReceiveTrDto> GetItemDataReceivedetails(long Id, long IvReceiveHdId)
        {
            var result = (from a in _repoIvReceiveTr.GetAll()
                          join pg in _repoIvReceiveHd.GetAll()
                          on a.IvReceiveHdId equals pg.Id into pgs
                          from m in pgs.DefaultIfEmpty()
                          join rs in _repoIvReturnReceiveTr.GetAll()
                          on a.Id equals rs.IvReceiveTrId into drocs
                          from drocst in drocs.DefaultIfEmpty()
                          join rs in _repoIvItems.GetAll()
                          on a.IvItemId equals rs.Id into droc
                          from dro in droc.DefaultIfEmpty()
                          where a.IvReceiveHdId == IvReceiveHdId && a.IvItemId == Id
                          select new IvReturnReceiveTrDto
                          {
                              Id = a.IvItemId,
                              UnitPrice = a.UnitPrice,
                              IvReceiveTrId = a.Id,
                              AvailableQty = a.Qty,
                              FndTaxtypeId = dro.FndTaxtypeId.Value,
                              Percentage = dro.FndTaxType.Percentage

                          }).AsQueryable().FirstOrDefault();
            var sumQty = _repoIvReturnReceiveTr.GetAll().Where(x => x.IvReceiveTrId == result.IvReceiveTrId).Sum(x => x.RQty);
            result.AvailableQty = result.AvailableQty - sumQty;

            var listDto = ObjectMapper.Map<IvReturnReceiveTrDto>(result);


            return listDto;

        }

        public async Task<List<IvReturnReceiveTrDto>> GetAllReturnReceivelistDetails(EntityDto<long> input)
        {
            var listData = await _repoIvReturnReceiveTr.GetAllIncluding(x => x.IvReceiveTr, x => x.IvReceiveTr.IvItems)
                               .Where(d => d.IvReturnReceiveHdId == input.Id).ToListAsync();

            var listDto = ObjectMapper.Map<List<IvReturnReceiveTrDto>>(listData);
            foreach (var item in listDto)
            {
                item.ItemName = item.IvReceiveTr.Item;
                item.IvItemId = item.IvReceiveTr.IvItemId;
                //(Qty*unitprice)+taxamount
                item.totbeforetax = item.RQty * item.UnitPrice;
                item.Totalamount = item.totbeforetax + item.TaxAmount;
            }

            return listDto;

        }

        public async Task<PostOutput> PostIvReturnReceiveHd(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _ivReturnReceiveHdPostRepository.Execute(postDto, "IvReturnReceiveHdPost");

            return result.FirstOrDefault();
        }


        public async Task<IvReturnReceiveHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var data = ObjectMapper.Map<IvReturnReceiveHdDto>(await Repository.GetAllIncluding(x => x.FndLookupStatusLkp, x => x.Currency, x => x.IvReceiveHd, x => x.IvReturnReceiveTrs)
                                                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync());
            return data;
        }


        private async Task<string> GetReturnreceiveNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvReturnReceiveHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

    }
}
