using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr;
using ERP._System.__Warehouses._IvAdjustmentHd.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System.__Warehouses._PoPurchaseOrder.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvAdjustmentHd
{
    public class IvAdjustmentHdAppService : AsyncCrudAppService<IvAdjustmentHd, IvAdjustmentHdDto, long, PagedIvAdjustmentHdRequestDto, CreateIvAdjustmentHdDto, IvAdjustmentHdEditDto>,
        IIvAdjustmentHdAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPoPurchaseOrderPostRepository _poPurchaseOrderPostRepository;
        private readonly IRepository<IvAdjustmentTr, long> _repoIvAdjustmentTr;
        private readonly IRepository<IvWarehouseItems, long> _repoIvWarehouseItems;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IRepository<IvUserWarehousesPrivileges, long> _repoIvUserWarehousesPrivileges;
        private readonly IRepository<IvItems, long> _repoIvItems;

        public IvAdjustmentHdAppService(IRepository<IvAdjustmentHd, long> repository,
               IRepository<FndLookupValues, long> repoFndLookupValues,
               IGetCounterRepository repoProcCounter,
               IPoPurchaseOrderPostRepository poPurchaseOrderPostRepository,
               IRepository<IvWarehouseItems, long> repoIvWarehouseItems,
               IRepository<IvUserWarehousesPrivileges, long> repoIvUserWarehousesPrivileges,
               IRepository<IvItems, long> repoIvItems,
               IRepository<IvAdjustmentTr, long> repoIvAdjustmentTr) : base(repository)
        {
            _repoProcCounter = repoProcCounter;
            _repoIvAdjustmentTr = repoIvAdjustmentTr;
            _repoFndLookupValues = repoFndLookupValues;
            _repoIvWarehouseItems = repoIvWarehouseItems;
            _repoIvUserWarehousesPrivileges = repoIvUserWarehousesPrivileges;
            _poPurchaseOrderPostRepository = poPurchaseOrderPostRepository;
            _repoIvItems = repoIvItems;

            CreatePermissionName = PermissionNames.Pages_IvAdjustmentHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvAdjustmentHd_Update;
            DeletePermissionName = PermissionNames.Pages_IvAdjustmentHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvAdjustmentHd;
        }

        protected override IQueryable<IvAdjustmentHd> CreateFilteredQuery(PagedIvAdjustmentHdRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.FndLookupValuesAdjustmentTypeLkp, z => z.FndLookupValuesStatusLkpIvAdjustmentHd, z => z.IvWarehouses);

            if (input.Params != null && input.Params.IvWarehouseId != null && input.Params.IvWarehouseId != 0)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && input.Params.StatusLkpId != null && input.Params.StatusLkpId != 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.AdjustmentTypeLkpId != null && input.Params.AdjustmentTypeLkpId != 0)
                iqueryable = iqueryable.Where(z => z.AdjustmentTypeLkpId == input.Params.AdjustmentTypeLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AdjustmentNumber))
                iqueryable = iqueryable.Where(z => z.AdjustmentNumber == input.Params.AdjustmentNumber);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AdjustmentDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.AdjustmentDate);

                iqueryable = iqueryable.Where(z => z.AdjustmentDate == dt);
            }

            return iqueryable;
        }

        public async override Task<IvAdjustmentHdDto> Create(CreateIvAdjustmentHdDto input)
        {
            CheckCreatePermission();

            input.AdjustmentNumber = await GetIvAdjustmentNumber();

            var ivAdjustmentHdDto = await base.Create(input);

            if (input.AdjustmentTr.Count > 0)
            {
                foreach (var item in input.AdjustmentTr)
                {
                    item.IvAdjustmentHdId = ivAdjustmentHdDto.Id;

                    var currentAdjustmentTr = ObjectMapper.Map<IvAdjustmentTr>(item);

                    _ = await _repoIvAdjustmentTr.InsertAsync(currentAdjustmentTr);
                }
            }

            return new IvAdjustmentHdDto { };
        }

        public async override Task<IvAdjustmentHdDto> Update(IvAdjustmentHdEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.AdjustmentTr.Count > 0)
            {
                foreach (var item in input.AdjustmentTr)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var propUnits = await _repoIvAdjustmentTr.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, propUnits);

                        _ = await _repoIvAdjustmentTr.UpdateAsync(propUnits);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {

                        item.IvAdjustmentHdId = input.Id;

                        _ = await _repoIvAdjustmentTr.InsertAsync(ObjectMapper.Map<IvAdjustmentTr>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoIvAdjustmentTr.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new IvAdjustmentHdDto { };
        }

        public async Task<IvAdjustmentHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesAdjustmentTypeLkp, z => z.FndLookupValuesStatusLkpIvAdjustmentHd, z => z.IvWarehouses)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            return ObjectMapper.Map<IvAdjustmentHdDto>(current);
        }

        public async Task<List<IvAdjustmentTrDto>> GetAllAdjustmentTr(EntityDto<long> input)
        {
            var output = new List<IvAdjustmentTrDto>();

            var listData = await _repoIvAdjustmentTr.GetAllIncluding(z => z.IvItems)
                .Where(d => d.IvAdjustmentHdId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new IvAdjustmentTrDto
                {
                    Id = item.Id,
                    CurrentQty = item.CurrentQty == null ? 0 : item.CurrentQty,
                    Qty = item.Qty,
                    IvItemId = item.IvItemId,
                    IvAdjustmentHdId = item.IvAdjustmentHdId,
                    IvItemName = item.IvItems == null ? string.Empty : item.IvItems.ItemName,
                    IvItemNumber = item.IvItems == null ? string.Empty : item.IvItems.ItemNumber,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<GetNumberQtyOutput> GetNumberQty(GetNumberQtyInput getNumberQtyInput)
        {
            var listData = await _repoIvWarehouseItems.GetAllIncluding(z => z.IvItems)
                .Where(d => d.IvItemId == getNumberQtyInput.IvItemId && d.IvWarehouseId == getNumberQtyInput.IvWarehouseId).FirstOrDefaultAsync();

            var current = new GetNumberQtyOutput
            {
                ItemNumber = listData == null || listData.IvItems == null ? _repoIvItems.FirstOrDefaultAsync(x => x.Id == getNumberQtyInput.IvItemId.Value).Result.ItemNumber : listData.IvItems.ItemNumber,
                CurrentOnHand = listData == null ? 0 : listData.CurrentOnHand
            };

            return current;
        }

        public async Task<Select2PagedResult> GetIvWarehousesByUserIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoIvUserWarehousesPrivileges.GetAllIncluding(z => z.IvWarehouses,x=>x.IvInventorySetting)
              .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.IvWarehouses.WarehouseName.Contains(searchTerm) && z.IvInventorySetting.UserId == AbpSession.UserId : z.IvWarehouses.WarehouseName.Contains(searchTerm) && z.IvInventorySetting.UserId == AbpSession.UserId))
              .ToListAsync();

            data = data.DistinctBy(x => x.IvWarehouseId).ToList();

            var result = data.OrderBy(q => q.IvWarehouses.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.IvWarehouses.Id, text = lang == "ar-EG" ? z.IvWarehouses.WarehouseName : z.IvWarehouses.WarehouseName }).Distinct().ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = result.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public override Task Delete(EntityDto<long> input)
        {
            var list = _repoIvAdjustmentTr.GetAll().Where(x => x.IvAdjustmentHdId == input.Id);

            foreach (var item in list) _repoIvAdjustmentTr.Delete(item);

            return base.Delete(input);
        }

        public async Task<PostOutput> PostIvAdjustmentHd(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _poPurchaseOrderPostRepository.Execute(postDto, "IvAdjustmentPost");

            return result.FirstOrDefault();
        }

        public async Task<(long id, string name)> GetAdjustmentHdAdjustmentStoredEntryType(string lang = "ar-EG")
        {
            long storedEntryTypeId = 769;

            var data = await _repoFndLookupValues.GetAsync(storedEntryTypeId);

            return (data?.Id ?? 0, lang == "ar-EG" ? data?.NameAr ?? string.Empty : data?.NameEn ?? string.Empty);
        }

        private async Task<string> GetIvAdjustmentNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvAdjustmentHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
