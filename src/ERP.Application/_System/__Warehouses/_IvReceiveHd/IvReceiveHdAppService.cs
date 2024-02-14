using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvItems.Dto;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._IvReceiveHd.Dto;
using ERP._System.__Warehouses._IvReceiveHd.Proc;
using ERP._System.__Warehouses._IvReceiveHd.ProcDto;
using ERP._System.__Warehouses._IvReturnReceiveHd;
using ERP._System.__Warehouses._IvUnits;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP._System.__Warehouses._PoPurchaseOrder.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvReceiveHd
{
    [AbpAuthorize]
    public class IvReceiveHdAppService : AsyncCrudAppService<IvReceiveHd, IvReceiveHdDto, long, IvReceiveHdPagedDto, IvReceiveHdCreateDto, IvReceiveHdEditDto>,
        IIvReceiveHdAppService
    {
        private readonly IIvUnitsManager _ivUnitsManager;
        private readonly IIvItemsManager _ivItemsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IIvUserWarehousesPrivilegesManager _ivUserWarehousesPrivilegesManager;
        private readonly IPoPurchaseOrderHdManager _poPurchaseOrderHdManager;
        private readonly IPoPurchaseOrderPostRepository _poPurchaseOrderPostRepository;
        private readonly IRepository<IvReceiveTr, long> _repoIvReceiveTr;
        private readonly IRepository<PoPurchaseOrderTr, long> _repoPoPurchaseOrderTr;
        private readonly IGetIvReceiveHdScreenDataRepository _getIvReceiveHdScreenDataRepository;
        private readonly IRepository<IvReturnReceiveTr, long> _repoIvReturnReceiveTr;
        private readonly IRepository<IvItems, long> _repoIvitems;
        


        public IvReceiveHdAppService(IRepository<IvReceiveHd, long> repository, IRepository<PoPurchaseOrderTr, long> repoPoPurchaseOrderTr,
            IRepository<IvReceiveTr, long> repoIvReceiveTr, IIvUnitsManager ivUnitsManager, IIvItemsManager ivItemsManager,
            IGetCounterRepository getCounterRepository, IIvUserWarehousesPrivilegesManager ivUserWarehousesPrivilegesManager,
            IGetIvReceiveHdScreenDataRepository getIvReceiveHdScreenDataRepository,
            IPoPurchaseOrderHdManager poPurchaseOrderHdManager,
            IRepository<IvReturnReceiveTr, long> repoIvReturnReceiveTr,
             IRepository<IvItems, long> repoIvitems,
            IPoPurchaseOrderPostRepository poPurchaseOrderPostRepository)
            : base(repository)
        {
            _ivUnitsManager = ivUnitsManager;
            _ivItemsManager = ivItemsManager;
            _repoProcCounter = getCounterRepository;
            _repoPoPurchaseOrderTr = repoPoPurchaseOrderTr;
            _poPurchaseOrderPostRepository = poPurchaseOrderPostRepository;
            _ivUserWarehousesPrivilegesManager = ivUserWarehousesPrivilegesManager;
            _poPurchaseOrderHdManager = poPurchaseOrderHdManager;
            _repoIvReceiveTr = repoIvReceiveTr;
            _getIvReceiveHdScreenDataRepository = getIvReceiveHdScreenDataRepository;
            _repoIvReturnReceiveTr = repoIvReturnReceiveTr;
            _repoIvitems = repoIvitems;


            CreatePermissionName = PermissionNames.Pages_IvReceiveHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvReceiveHd_Update;
            DeletePermissionName = PermissionNames.Pages_IvReceiveHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvReceiveHd;
        }

        protected override IQueryable<IvReceiveHd> CreateFilteredQuery(IvReceiveHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.IvWarehouses,
                                        x => x.PoPurchaseOrderHd, x=>x.IvReceiveTr,
                                        x => x.ApVendors, x => x.IvWarehouses.IvUserWarehousesPrivileges);

            long userId = (long)AbpSession.UserId;

            iqueryable = iqueryable.Where(z => z.IvWarehouses.IvUserWarehousesPrivileges.Any(x => x.IvInventorySetting.UserId == userId && x.HasReceive));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdReceiveNumber))
                iqueryable = iqueryable.Where(z => z.HdReceiveNumber.Contains(input.Params.HdReceiveNumber));

            if (input.Params != null && input.Params.IvWarehouseId != null)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.VendorId == input.Params.VendorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdReceiveDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.HdReceiveDate);

                iqueryable = iqueryable.Where(z => z.HdReceiveDate == dt);
            }

            return iqueryable;
        }

        public async override Task<IvReceiveHdDto> Create(IvReceiveHdCreateDto input)
        {
            CheckCreatePermission();

            if (input.IvReceiveDetails == null || input.IvReceiveDetails.Count == 0)
                throw new UserFriendlyException("يحب ملئ علي الاقل سند مواد واحد!");

            input.HdReceiveNumber = await GetInvoiceCounter();

            var ivReceiveHd = await base.Create(input);

            if (input.IvReceiveDetails != null && input.IvReceiveDetails.Count > 0)
            {
                foreach (var item in input.IvReceiveDetails)
                {
                    item.IvReceiveHdId = ivReceiveHd.Id;

                    var ivReceiveTr = ObjectMapper.Map<IvReceiveTr>(item);

                    _ = await _repoIvReceiveTr.InsertAsync(ivReceiveTr);
                }
            }

            return new IvReceiveHdDto { };
        }

        public async override Task<IvReceiveHdDto> Update(IvReceiveHdEditDto input)
        {
            CheckUpdatePermission();

            if (input.IvReceiveDetails == null || input.IvReceiveDetails.Count == 0)
                throw new UserFriendlyException("يحب ملئ علي الاقل سند مواد واحد!");

            _ = await base.Update(input);

            if (input.IvReceiveDetails != null && input.IvReceiveDetails.Count > 0)
            {
                foreach (var item in input.IvReceiveDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spContractDetails = await _repoIvReceiveTr.GetAsync((long)item.Id);

                        item.IvReceiveHdId = input.Id;

                        ObjectMapper.Map(item, spContractDetails);

                        _ = await _repoIvReceiveTr.UpdateAsync(spContractDetails);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.IvReceiveHdId = input.Id;

                        _ = await _repoIvReceiveTr.InsertAsync(ObjectMapper.Map<IvReceiveTr>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoIvReceiveTr.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new IvReceiveHdDto { };
        }

        public async Task<List<IvReceiveTrDto>> GetIvReceiveTrDetails(EntityDto<long> input)
        {
            var listData = await _repoIvReceiveTr.GetAllIncluding(x => x.IvItems, x => x.IvUnits)
                               .Where(d => d.IvReceiveHdId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<IvReceiveTrDto>>(listData);
        }

        //public async Task<IvReceiveHdDto> GetDetailAsync(EntityDto<long> input)
        //      => ObjectMapper.Map<IvReceiveHdDto>(await Repository
        //        .GetAllIncluding( x => x.ApVendors, x => x.PoPurchaseOrderHd,
        //              x => x.FndStatusLkp, x => x.Currency, x => x.IvWarehouses)
        //        .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<IvReceiveHdDto> GetDetailAsync(EntityDto<long> input)
        { 
        var obj= ObjectMapper.Map<IvReceiveHdDto>(await Repository
               .GetAllIncluding(x => x.ApVendors, x => x.PoPurchaseOrderHd, x => x.IvReceiveTr,
                     x => x.FndStatusLkp, x => x.Currency, x => x.IvWarehouses)
               .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            return obj;

        }

        public async Task<List<IvReceiveTrDto>> GetItemsPurchaseOrder(long purchaseOrderId, long receiveTypeLkpId)
        {
            if (receiveTypeLkpId == 0) return new List<IvReceiveTrDto>();

            var data = await _repoPoPurchaseOrderTr.GetAllIncluding(x => x.Items, x => x.Items.IvUnits)
                                                   .Where(z => z.PoPurchaseOrderId == purchaseOrderId)
                                                   .Where(z => (receiveTypeLkpId == /*Donated Items*/ 765 ? (bool)z.Items.IsDonationItem : (bool)!z.Items.IsDonationItem))
                                                   .ToListAsync();

            return ObjectMapper.Map<List<IvReceiveTrDto>>(data);
        }

        public async Task<PostOutput> PostIvReceiveHd(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _poPurchaseOrderPostRepository.Execute(postDto, "IvReceivePost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetIvItemsSelect2(long IvReceiveHdReceiveTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ivItemsManager.GetIvItemsForReceiveSelect2(IvReceiveHdReceiveTypeId, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ivUnitsManager.GetIvUnitsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPurchaseOrderSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _poPurchaseOrderHdManager.GetPurchaseOrderSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ivUserWarehousesPrivilegesManager.GetIvUserWarehousesPrivilegesSelect2((long)AbpSession.UserId, searchTerm, pageSize, pageNumber, lang);

        public async Task<List<IvReceiveHdScreenDataOutput>> GetIvReceiveHdScreenData(IdLangInputDto input)
        {
            var result = await _getIvReceiveHdScreenDataRepository.Execute(input, "GetIvReceiveHdScreenData");

            return result.ToList();
        }

        public async Task<Select2PagedResult> GetIvReceiveSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var datafilter = Repository.GetAll().Where(x => x.StatusLkpId == 764);
            var data = datafilter.Where(z => string.IsNullOrEmpty(searchTerm) || z.HdReceiveNumber.Contains(searchTerm));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.HdReceiveNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<IvReceiveHdDto> GetReceiveData(long Id)
        {
            var result = await Repository.GetAllIncluding(x => x.IvWarehouses, x => x.ApVendors, x => x.Currency, x => x.FndStatusLkp, x => x.IvReceiveTr)
                                              .Where(z => z.Id == Id).FirstOrDefaultAsync();

            var listDto = ObjectMapper.Map<IvReceiveHdDto>(result);

            return listDto;
        }


        public async Task<Select2PagedResult> GetIvItemByReceiveelect2(string searchTerm, int pageSize, int pageNumber, string lang, long IvReceiveHdId)
        {
            var receivedata = _repoIvReceiveTr.GetAll().Where(x => x.IvReceiveHdId == IvReceiveHdId);
            var IvReceiveTrlist = new List<IvReceiveTr>();
            foreach (var receive in receivedata)
            {
                var returnsaledata = _repoIvReturnReceiveTr.GetAll().Where(x => x.IvReceiveTrId == receive.Id);
                var GetSum = returnsaledata.Sum(x => x.RQty);
                if (receive.Qty > GetSum)
                {
                    IvReceiveTrlist.Add(receive);

                }
            }
            var data = (from s in IvReceiveTrlist
                        join n in _repoIvitems.GetAll()
                        on s.IvItemId equals n.Id
                        select new IvItemsDto
                        {
                            Id = n.Id,
                            ItemName = n.ItemName,
                            ItemNumber = n.ItemNumber
                        }).ToList();





            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };



            return select2pagedResult;


            //return null;
        }





        private async Task<string> GetInvoiceCounter(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvReceiveHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
