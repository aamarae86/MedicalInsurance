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

namespace ERP._System.__Warehouses.__IvInventorySetting
{
    [AbpAuthorize]
    public class IvInventorySettingAppService : AsyncCrudAppService<IvInventorySetting, IvInventorySettingDto, long, IvInventorySettingPagedDto, IvInventorySettingCreateDto, IvInventorySettingEditDto>, IIvInventorySettingAppService
    {
        private readonly IRepository<IvInventorySettingPriceList, long> _repoIvInventorySettingPriceList;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<IvItems, long> _repoIvItems;
        private readonly IIvItemsAppService _ivItemsService;
        private readonly IRepository<User, long> _repoUser;
        private readonly IRepository<IvUserWarehousesPrivileges, long> _repoUserWarehousesPrivileges;
        public IvInventorySettingAppService(IRepository<IvInventorySetting, long> repository,
          IRepository<IvInventorySettingPriceList, long> repoIvInventorySettingPriceList, IRepository<IvItems, long> repoIvItems,
           IRepository<User, long> repoUser, IRepository<IvUserWarehousesPrivileges, long> repoUserWarehousesPrivileges,
          IGetCounterRepository getCounterRepository, IIvItemsAppService ivItemsService) : base(repository)
        {
            _repoIvInventorySettingPriceList = repoIvInventorySettingPriceList;
            _repoProcCounter = getCounterRepository;
            _ivItemsService = ivItemsService;
            _repoIvItems = repoIvItems;
            _repoUser = repoUser;
            _repoUserWarehousesPrivileges = repoUserWarehousesPrivileges;

            CreatePermissionName = PermissionNames.Pages_IvInventorySetting_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvInventorySetting_Update;
            DeletePermissionName = PermissionNames.Pages_IvInventorySetting_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvInventorySetting;
        }



        protected override IQueryable<IvInventorySetting> CreateFilteredQuery(IvInventorySettingPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.User);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SettingNumber))
                iqueryable = iqueryable.Where(z => z.SettingNumber.Contains(input.Params.SettingNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.UserId.ToString()) && input.Params.UserId != 0)
                iqueryable = iqueryable.Where(z => z.UserId.ToString().Contains(input.Params.UserId.ToString()));

            return iqueryable;
        }

        public async override Task<IvInventorySettingDto> Create(IvInventorySettingCreateDto input)
        {
            CheckCreatePermission();
            input.SettingNumber = await GetSettingNumber();
            var IvInventorySettingList = ObjectMapper.Map<IvInventorySetting>(input);

            _ = await Repository.InsertAsync(IvInventorySettingList);

            if (input.InventorySettingPriceListDetails != null && input.InventorySettingPriceListDetails.Count > 0)
                foreach (var item in input.InventorySettingPriceListDetails)
                    await InsertInventorySettingPriceListData(item, IvInventorySettingList.Id);


            if (input.UserWarehousesPrivilegesDetails != null && input.UserWarehousesPrivilegesDetails.Count > 0)
                foreach (var item in input.UserWarehousesPrivilegesDetails)
                    await InsertWarehousesPrivilegesData(item, IvInventorySettingList.Id);

            return new IvInventorySettingDto { };
        }
        #region pricelist
        public async Task<List<IvInventorySettingPriceListDto>> GetAllInventorySettingPricelistDetails(EntityDto<long> input)
        {
            var listData = await _repoIvInventorySettingPriceList.GetAllIncluding(x => x.IvPriceListHd)
                               .Where(d => d.IvInventorySettingId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<IvInventorySettingPriceListDto>>(listData);
        }
        private async Task InsertInventorySettingPriceListData(IvInventorySettingPriceListDto InventorySettingPriceListDto, long masterId)
        {
            try
            {
                InventorySettingPriceListDto.IvInventorySettingId = masterId;

                var InventorySettingPriceList = ObjectMapper.Map<IvInventorySettingPriceList>(InventorySettingPriceListDto);

                if (InventorySettingPriceList != null)
                    InventorySettingPriceList.IvPriceListHd = null;

                _ = await _repoIvInventorySettingPriceList.InsertAsync(InventorySettingPriceList);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async override Task<IvInventorySettingDto> Update(IvInventorySettingEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            await CRUD_IvInventorySetting(input.InventorySettingPriceListDetails, input.Id);
            await CRUD_WarehousePrivilage(input.UserWarehousesPrivilegesDetails, input.Id);

            return new IvInventorySettingDto { };
        }
        private async Task CRUD_IvInventorySetting(ICollection<IvInventorySettingPriceListDto> IvInventorySettingPriceListDtos, long masterId)
        {
            try
            {
                if (IvInventorySettingPriceListDtos != null && IvInventorySettingPriceListDtos.Count > 0)
                {
                    foreach (var item in IvInventorySettingPriceListDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var IvInventorySettingPriceList = await _repoIvInventorySettingPriceList.GetAsync((long)item.Id);

                            item.IvInventorySettingId = masterId;

                            ObjectMapper.Map(item, IvInventorySettingPriceList);
                            if (IvInventorySettingPriceList != null)
                                IvInventorySettingPriceList.IvPriceListHd = null;

                            _ = await _repoIvInventorySettingPriceList.UpdateAsync(IvInventorySettingPriceList);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertInventorySettingPriceListData(item, masterId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoIvInventorySettingPriceList.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region warehouse
        private async Task CRUD_WarehousePrivilage(ICollection<IvUserWarehousesPrivilegesExtDto> IvUserWarehousesPrivilegesDto, long masterId)
        {
            try
            {
                if (IvUserWarehousesPrivilegesDto != null && IvUserWarehousesPrivilegesDto.Count > 0)
                {
                    foreach (var item in IvUserWarehousesPrivilegesDto)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var IvUserWarehousesPrivilegesList = await _repoUserWarehousesPrivileges.GetAsync((long)item.Id);

                            item.IvInventorySettingId = masterId;
                            ObjectMapper.Map(item, IvUserWarehousesPrivilegesList);
                            if (IvUserWarehousesPrivilegesList != null)
                                IvUserWarehousesPrivilegesList.IvWarehouses = null;

                            _ = await _repoUserWarehousesPrivileges.UpdateAsync(IvUserWarehousesPrivilegesList);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertWarehousesPrivilegesData(item, masterId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoUserWarehousesPrivileges.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<IvUserWarehousesPrivilegesExtDto>> GetAllWarehousePrivilageDetails(EntityDto<long> input)
        {
            try
            {
                var listData = await _repoUserWarehousesPrivileges.GetAllIncluding(x=>x.IvWarehouses)
                                   .Where(d => d.IvInventorySettingId == input.Id).ToListAsync();

                return ObjectMapper.Map<List<IvUserWarehousesPrivilegesExtDto>>(listData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task InsertWarehousesPrivilegesData(IvUserWarehousesPrivilegesExtDto UserWarehousesPrivilegesDto, long masterId)
        {
            try
            {
                UserWarehousesPrivilegesDto.IvInventorySettingId = masterId;
                var UserWarehousesPrivilegesList = ObjectMapper.Map<IvUserWarehousesPrivileges>(UserWarehousesPrivilegesDto);

                if (UserWarehousesPrivilegesList != null)
                    UserWarehousesPrivilegesList.IvWarehouses = null;

                _ = await _repoUserWarehousesPrivileges.InsertAsync(UserWarehousesPrivilegesList);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion
        private async Task<string> GetSettingNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvInventorySetting", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        public async Task<Select2PagedResult> GetPricelistByUserIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            
            var data = await _repoIvInventorySettingPriceList.GetAllIncluding(z => z.IvPriceListHd, z => z.IvInventorySetting)
                                              .Where(z => z.IvInventorySetting.UserId == AbpSession.UserId)
                                              .Where(z => string.IsNullOrEmpty(searchTerm) || (z.IvPriceListHd.PriceListName.Contains(searchTerm)))
                                              .ToListAsync();

           

            var result = data.OrderBy(q => q.IvPriceListHd.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.IvPriceListHd.Id, text = z.IvPriceListHd.PriceListName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<IvInventorySettingPriceListDto> GetFirstPricelistByUserId()
        {

            var data = await _repoIvInventorySettingPriceList.GetAllIncluding(z => z.IvPriceListHd, z => z.IvInventorySetting)
                                              .Where(z => z.IvInventorySetting.UserId == AbpSession.UserId)                                             
                                              .FirstOrDefaultAsync();
            var obj= ObjectMapper.Map<IvInventorySettingPriceListDto>(data);
            return obj;
            
        }



        public async Task<Select2PagedResult> GetUsersNotInpriceListSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoUser.GetAll()
                         //.Where(c => !Repository.GetAll()
                         //.Select(b => b.UserId)
                         //.Contains(c.Id))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.UserName : z.UserName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<IvInventorySettingDto> GetDetailAsync(EntityDto<long> input)
           => ObjectMapper.Map<IvInventorySettingDto>(await Repository.GetAllIncluding(x => x.User)
                                       .Where(z => z.Id == input.Id).FirstOrDefaultAsync());
    }
}
