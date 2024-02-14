using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._PoPurchaseOrder.Dto;
using ERP._System.__Warehouses._PoPurchaseOrder.Proc;
using ERP._System.__Warehouses._PoPurchaseOrder.ProcDto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public class PoPurchaseOrderAppService : AsyncCrudAppService<PoPurchaseOrderHd, PoPurchaseOrderDto, long, PoPurchaseOrderPagedDto, PoPurchaseOrderCreateDto, PoPurchaseOrderEditDto>
        , IPoPurchaseOrderAppService
    {
        private readonly IRepository<PoPurchaseOrderTr, long> _repoDetails;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPoPurchaseOrderPostRepository _poPurchaseOrderPostRepository;
        private readonly IGetPoPurchaseOrderScreenDataRepository _getPoPurchaseOrderScreenDataRepository;

        public PoPurchaseOrderAppService(IRepository<PoPurchaseOrderTr, long> repoDetails
            , IRepository<PoPurchaseOrderHd, long> repository
            , IGetPoPurchaseOrderScreenDataRepository getPoPurchaseOrderScreenDataRepository
            , IGetCounterRepository repoProcCounter
            , IPoPurchaseOrderPostRepository poPurchaseOrderPostRepository
            ) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_PoPurchaseOrder_Insert;
            UpdatePermissionName = PermissionNames.Pages_PoPurchaseOrder_Update;
            DeletePermissionName = PermissionNames.Pages_PoPurchaseOrder_Delete;
            GetAllPermissionName = PermissionNames.Pages_PoPurchaseOrder;

            _repoDetails = repoDetails;
            _repoProcCounter = repoProcCounter;
            _poPurchaseOrderPostRepository = poPurchaseOrderPostRepository;
            _getPoPurchaseOrderScreenDataRepository = getPoPurchaseOrderScreenDataRepository;
        }

        public override async Task<PoPurchaseOrderDto> Create(PoPurchaseOrderCreateDto input)
        {
            CheckCreatePermission();

            input.PurchaseOrderNumber = await GetPurchaseOrderNumber();

            var PurchaseOrder = await base.Create(input);

            if (input.ListOfCreateDetails?.Count > 0)
                foreach (var item in input.ListOfCreateDetails)
                {
                    item.PoPurchaseOrderId = PurchaseOrder.Id;

                    var PoPurchaseOrderDetail = ObjectMapper.Map<PoPurchaseOrderTr>(item);

                    _ = await _repoDetails.InsertAsync(PoPurchaseOrderDetail);

                }

            return null;
        }

        public override async Task<PoPurchaseOrderDto> Update(PoPurchaseOrderEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.ListOfEditDetails?.Count > 0)
            {
                foreach (var item in input.ListOfEditDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.PoPurchaseOrderId = input.Id;

                        var PoPurchaseOrderMember = await _repoDetails.GetAsync((long)item.Id);

                        var mapped = ObjectMapper.Map(item, PoPurchaseOrderMember);

                        _ = await _repoDetails.UpdateAsync(PoPurchaseOrderMember);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PoPurchaseOrderId = input.Id;

                        var PoPurchaseOrderMember = ObjectMapper.Map<PoPurchaseOrderTr>(item);

                        _ = await _repoDetails.InsertAsync(PoPurchaseOrderMember);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetails.DeleteAsync((long)item.Id);
                    }
                }
            }
            return new PoPurchaseOrderDto { };
        }

        public async Task<PoPurchaseOrderDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<PoPurchaseOrderDto>(await Repository.GetAll()
                .Include(z => z.FndLookupValuesStatusLkp)
                .Include(z => z.Vendor)
                .Include(z => z.Warehouses)
                .Include(z => z.PoPurchaseOrderTrs).ThenInclude(d => d.Items)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync());

        protected override IQueryable<PoPurchaseOrderHd> CreateFilteredQuery(PoPurchaseOrderPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.FndLookupValuesStatusLkp
                , z => z.Vendor, z => z.Warehouses
                , z => z.PoPurchaseOrderTrs);

            if (input.Params != null && input.Params.IvWarehouseId != null)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && input.Params.StatusId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OrderNumber))
                iqueryable = iqueryable.Where(z => z.PurchaseOrderNumber.Contains(input.Params.OrderNumber));

            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.VendorId == input.Params.VendorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PurchaseOrderDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.PurchaseOrderDate);
                iqueryable = iqueryable.Where(z => z.PurchaseOrderDate == dt);
            }

            return iqueryable;
        }

        public async Task<PostOutput> PostPoPurchaseOrder(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _poPurchaseOrderPostRepository.Execute(postDto, "PoPurchaseOrderPost");

            return result.FirstOrDefault();
        }

        public async Task<List<PoPurchaseOrderScreenDataOutput>> GetPoPurchaseOrderScreenData(IdLangInputDto input)
        {
            var result = await _getPoPurchaseOrderScreenDataRepository.Execute(input, "GetPoPurchaseOrderScreenData");

            return result.ToList();
        }

        private async Task<string> GetPurchaseOrderNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PoPurchaseOrderHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }
    }
}
