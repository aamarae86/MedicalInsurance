using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndCollectors.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._FndSalesMen
{
    [AbpAuthorize]
    public class FndSalesMenAppService : AsyncCrudAppService<FndSalesMen, FndSalesMenDto, long, PagedFndSalesMenResultRequestDto, CreateFndSalesMenDto, FndSalesMenEditDto>, IFndSalesMenAppService
    {
           
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IFndSalesMenManager _fndSalesMenManager;

        public FndSalesMenAppService(IRepository<FndSalesMen, long> repository,                
            IGetCounterRepository getCounterRepository,
            IFndSalesMenManager fndSalesMenManager) : base(repository)
        {
               
            _repoProcCounter = getCounterRepository;
            _fndSalesMenManager = fndSalesMenManager;

            CreatePermissionName = PermissionNames.Pages_FndSalesMen_Insert;
            UpdatePermissionName = PermissionNames.Pages_FndSalesMen_Update;
            DeletePermissionName = PermissionNames.Pages_FndSalesMen_Delete;
            GetAllPermissionName = PermissionNames.Pages_FndSalesMen;
        }

        public async override Task<FndSalesMenDto> Create(CreateFndSalesMenDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "FndSalesMen", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.SalesManNo = result?.FirstOrDefault()?.OutputStr ?? "SalemanNo";

            return await base.Create(input);
        }

        public async Task<bool> GetExistSalesMenNameArAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                        .Where(x => x.SalesManNameAr.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistSalesMenNameEnAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                        .Where(x => x.SalesManNameEn.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }
        public async override Task<PagedResultDto<FndSalesMenDto>> GetAll(PagedFndSalesMenResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll();

            if (!string.IsNullOrEmpty(input.Params.SalesManNameAr))
            {
                queryable = queryable.Where(q => q.SalesManNameAr.Contains(input.Params.SalesManNameAr));
            }

            if (!string.IsNullOrEmpty(input.Params.SalesManNameEn))
            {
                queryable = queryable.Where(q => q.SalesManNameEn.Contains(input.Params.SalesManNameEn));
            }

            if (!string.IsNullOrEmpty(input.Params.SalesManNo))
            {
                queryable = queryable.Where(q => q.SalesManNo == input.Params.SalesManNo);
            }

            if ((input.Params.IsActive != null))
            {
                queryable = queryable.Where(q => q.IsActive == input.Params.IsActive);                    
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<FndSalesMenDto>());

            var PagedResultDto = new PagedResultDto<FndSalesMenDto>()
            {
                Items = data2 as IReadOnlyList<FndSalesMenDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }
        public async Task<Select2PagedResult> GetFndSalesMenSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndSalesMenManager.GetFndSalesMenSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<long?> GetSalesMenNameByNameAsync(string name)
        {
            var current = await Repository.GetAll()
                        .Where(x => x.SalesManNameEn.ToLower() == name.ToLower()).FirstOrDefaultAsync();

            return current?.Id;
        }

        public async override Task<FndSalesMenDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x=> x.User).Where(z => z.Id == input.Id).FirstOrDefaultAsync();
            //var current = await Repository.GetAll().Include(x=> x.User).FirstOrDefaultAsync();
            return ObjectMapper.Map<FndSalesMenDto>(current);
        }

        public async Task<FndSalesMenDto> GetSalesManByUserId()
        {
            var userid = AbpSession.UserId;
            var current = await Repository.GetAllIncluding(x => x.User).Where(z => z.UserId == userid).FirstOrDefaultAsync();
            return ObjectMapper.Map<FndSalesMenDto>(current);
        }
    }
}
