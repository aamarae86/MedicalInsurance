using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._GlAccMappingHd;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP._System.__AccountModuleExtend._GlAccMapping.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlAccMapping
{
    [AbpAuthorize]
    public class GlAccMappingHdAppService : AsyncCrudAppService<GlAccMappingHd, GlAccMappingHdDto, long, GlAccMappingHdPagedDto, GlAccMappingHdCreateDto, GlAccMappingHdEditDto>,
        IGlAccMappingHdAppService
    {
        private readonly IRepository<GlAccMappingTr, long> _repoGlAccMappingTr;
        private readonly IRepository<GlAccMappingTrDtl, long> _repoGlAccMappingTrDtl;
        private readonly IGlAccMappingHdManager _glAccMappingHdManager;
        private readonly IGetCounterRepository _repoProcCounter;

        public GlAccMappingHdAppService(IRepository<GlAccMappingHd, long> repository,
            IRepository<GlAccMappingTrDtl, long> repoGlAccMappingTrDtl,
            IRepository<GlAccMappingTr, long> repoGlAccMappingTr,
            IGlAccMappingHdManager glAccMappingHdManager,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _repoGlAccMappingTr = repoGlAccMappingTr;
            _repoGlAccMappingTrDtl = repoGlAccMappingTrDtl;
            _glAccMappingHdManager = glAccMappingHdManager;

            CreatePermissionName = PermissionNames.Pages_GlAccMappingHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlAccMappingHd_Update;
            DeletePermissionName = PermissionNames.Pages_GlAccMappingHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlAccMappingHd;
        }

        protected override IQueryable<GlAccMappingHd> CreateFilteredQuery(GlAccMappingHdPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MapNumber))
                iqueryable = iqueryable.Where(z => z.MapNumber.Contains(input.Params.MapNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MapName))
                iqueryable = iqueryable.Where(z => z.MapName.Contains(input.Params.MapName));

            return iqueryable;
        }

        public async Task<GlAccMappingHdDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<GlAccMappingHdDto>(await Repository.GetAll().Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async override Task<GlAccMappingHdDto> Create(GlAccMappingHdCreateDto input)
        {
            CheckCreatePermission();

            input.MapNumber = await GetAccMappingNumber();

            var current = await base.Create(input);

            if (input?.GlAccMappingTrList?.Count > 0)
                foreach (var item in input.GlAccMappingTrList)
                    await InsertGlAccMappingTr(item, current.Id);

            return current;
        }

        public async override Task<GlAccMappingHdDto> Update(GlAccMappingHdEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            await CRUD_GlAccMappingTr(input.GlAccMappingTrList, input.Id);

            return null;
        }

        public async Task<List<GlAccMappingTrDto>> GetAllGlAccMappingTr(EntityDto<long> input)
        {
            var data = await _repoGlAccMappingTr.GetAllIncluding(z => z.GlAccMappingTrDtl)
                                                .Where(z => z.GlAccMappingHdId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<GlAccMappingTrDto>>(data);
        }

        public async Task<List<GlAccMappingTrDtlDto>> GetAllGlAccMappingTrDtl(EntityDto<long> input)
        {
            var data = await _repoGlAccMappingTrDtl.GetAllIncluding(x => x.GlAccDetailFrom, x => x.GlAccDetailTo, x => x.FndTypeLkp)
                                                   .Where(z => z.GlAccMappingTrId == input.Id).ToListAsync();
            return ObjectMapper.Map<List<GlAccMappingTrDtlDto>>(data);
        }

        public async Task<Select2PagedResult> GetGlAccMappingHdSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glAccMappingHdManager.GetGlAccMappingHdSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<long> InsertGlAccMappingTr(GlAccMappingTrDto trDto, long glAccMappingHdId)
        {
            trDto.GlAccMappingHdId = glAccMappingHdId;

            var current = await _repoGlAccMappingTr.InsertAsync(ObjectMapper.Map<GlAccMappingTr>(trDto));

            if (trDto?.GlAccMappingTrDtlList?.Count > 0)
                foreach (var item in trDto.GlAccMappingTrDtlList) await InsertGlAccMappingTrDtl(item, current.Id);

            return current.Id;
        }

        private async Task InsertGlAccMappingTrDtl(GlAccMappingTrDtlDto trDtlDto, long glAccMappingTrId)
        {
            trDtlDto.GlAccMappingTrId = glAccMappingTrId;

            _ = await _repoGlAccMappingTrDtl.InsertAsync(ObjectMapper.Map<GlAccMappingTrDtl>(trDtlDto));
        }

        private async Task CRUD_GlAccMappingTr(ICollection<GlAccMappingTrDto> trDtos, long glAccMappingHdId)
        {
            if (trDtos != null && trDtos.Count > 0)
            {
                long? inRequestId = null;

                foreach (var item in trDtos)
                {
                    if (item.rowStatus == DetailRowStatus.RowStatus.NoAction.ToString())
                    {
                        await CRUD_GlAccMappingTrDtl(item.GlAccMappingTrDtlList, item.Id);
                        continue;
                    }

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var glAccMappingTr = await _repoGlAccMappingTr.GetAsync((long)item.Id);

                        item.GlAccMappingHdId = glAccMappingHdId;

                        ObjectMapper.Map(item, glAccMappingTr);

                        _ = await _repoGlAccMappingTr.UpdateAsync(glAccMappingTr);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var altList = item.GlAccMappingTrDtlList;

                        item.GlAccMappingTrDtlList = null;

                        long glAccMappingTrId = await InsertGlAccMappingTr(item, glAccMappingHdId);

                        item.GlAccMappingTrDtlList = altList;

                        inRequestId = glAccMappingTrId;
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoGlAccMappingTr.DeleteAsync((long)item.Id);
                    }

                    if (item.rowStatus != DetailRowStatus.RowStatus.NoAction.ToString())
                        await CRUD_GlAccMappingTrDtl(item.GlAccMappingTrDtlList, item.Id, inRequestId);
                }
            }
        }

        private async Task CRUD_GlAccMappingTrDtl(ICollection<GlAccMappingTrDtlDto> trDtlDtos, long glAccMappingTrId, long? inRequestId = null)
        {
            if (trDtlDtos != null && trDtlDtos.Count > 0 && trDtlDtos.Count(z => z.rowStatus == DetailRowStatus.RowStatus.NoAction.ToString()) != trDtlDtos.Count)
            {
                foreach (var item in trDtlDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var glAccMappingTrDtl = await _repoGlAccMappingTrDtl.GetAsync((long)item.Id);

                        item.GlAccMappingTrId = glAccMappingTrId;

                        ObjectMapper.Map(item, glAccMappingTrDtl);

                        _ = await _repoGlAccMappingTrDtl.UpdateAsync(glAccMappingTrDtl);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertGlAccMappingTrDtl(item, inRequestId ?? glAccMappingTrId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoGlAccMappingTrDtl.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task<string> GetAccMappingNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "GlAccMappingHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
