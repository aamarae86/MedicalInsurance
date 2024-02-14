using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System._GlPeriods.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System._GlPeriods
{
    [AbpAuthorize]
    public class GlPeriodsYearsAppService : AsyncCrudAppService<GlPeriodsYears, GlPeriodsYearsDto, long, PagedGlPeriodsYearsResultRequestDto, CreateGlPeriodsYearsDto, GlPeriodsYearsEditDto>, IGlPeriodsYearsAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IRepository<GlPeriodsDetails, long> _detailRepo;
        private readonly IGlPeriodsYearsManager _glPeriodsYearsManager;

        public GlPeriodsYearsAppService(IRepository<GlPeriodsYears, long> repository,
            IRepository<GlPeriodsDetails, long> detailsRepo,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IGlPeriodsYearsManager glPeriodsYearsManager) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _detailRepo = detailsRepo;
            _glPeriodsYearsManager = glPeriodsYearsManager;

            CreatePermissionName = PermissionNames.Pages_GlPeriodsYears_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlPeriodsYears_Update;
            DeletePermissionName = PermissionNames.Pages_GlPeriodsYears_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlPeriodsYears;
        }

        public async override Task<PagedResultDto<GlPeriodsYearsDto>> GetAll(PagedGlPeriodsYearsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.GlCodeComDetails);

            if (!string.IsNullOrEmpty(input.Params?.PeriodYear))
            {
                queryable = queryable.Where(q => q.PeriodYear.ToString().Contains(input.Params.PeriodYear));
            }

            if (!string.IsNullOrEmpty(input.Params?.StartDate))
            {
                DateTime startDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.StartDate);

                queryable = queryable.Where(z => (startDate >= z.StartDate && startDate <= z.EndDate));
            }

            if (!string.IsNullOrEmpty(input.Params?.EndDate))
            {
                DateTime endDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.EndDate);

                queryable = queryable.Where(z => (endDate >= z.StartDate && endDate <= z.EndDate));
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GlPeriodsYearsDto>());

            if (data2 != null && data2.Count > 0)
            {
                foreach (var item in data2)
                {
                    var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails,_app.Reqlanguage);

                    item.codeComUtilityTexts = currentCodeCom.texts;
                }
            }

            var PagedResultDto = new PagedResultDto<GlPeriodsYearsDto>()
            {
                Items = data2 as IReadOnlyList<GlPeriodsYearsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public override async Task<GlPeriodsYearsDto> Create(CreateGlPeriodsYearsDto input)
        {
            CheckCreatePermission();

            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            input.AccountId = (long)currentComCodeId;

            var glPeriodsYears = ObjectMapper.Map<GlPeriodsYears>(input);

            _ = await Repository.InsertAsync(glPeriodsYears);

            if (input.PeriodDetails.Count > 0)
            {
                long opendStatusId = Convert.ToInt64(FndEnum.FndLkps.Opened_GlPeriodsDetailsStatues);

                foreach (var item in input.PeriodDetails)
                {
                    item.StartDate = DateTimeController.ConvertToDateTime(item.StartDateStr);
                    item.EndDate = DateTimeController.ConvertToDateTime(item.EndDateStr);

                    GlPeriodsDetails glPeriodsDetails = ObjectMapper.Map<GlPeriodsDetails>(item);

                    glPeriodsDetails.setYearId(glPeriodsYears.Id);
                    glPeriodsDetails.setStatus(opendStatusId);
                    glPeriodsDetails.setStartDate(item.StartDateStr);
                    glPeriodsDetails.setEndDate(item.EndDateStr);

                    _ = await _detailRepo.InsertAsync(glPeriodsDetails);
                }
            }

            return MapToEntityDto(glPeriodsYears);
        }

        public override async Task<GlPeriodsYearsDto> Update(GlPeriodsYearsEditDto input)
        {
            CheckUpdatePermission();

            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            input.AccountId = (long)currentComCodeId;

            var glPeriodsYears = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, glPeriodsYears);

            _ = await Repository.UpdateAsync(glPeriodsYears);

            if (input.PeriodDetails.Count > 0)
            {
                long opendStatusId = Convert.ToInt64(FndEnum.FndLkps.Opened_GlPeriodsDetailsStatues);

                foreach (var item in input.PeriodDetails)
                {
                    item.StartDate = DateTimeController.ConvertToDateTime(item.StartDateStr);
                    item.EndDate = DateTimeController.ConvertToDateTime(item.EndDateStr);

                    if (item.Id > 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        //need to check or set flag for updated details only for the sake of performance
                        GlPeriodsDetails glPeriodsDetails = await _detailRepo.GetAsync(item.Id);
                        ObjectMapper.Map(item, glPeriodsDetails);

                        _ = await _detailRepo.UpdateAsync(glPeriodsDetails);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        GlPeriodsDetails glPeriodsDetails = ObjectMapper.Map<GlPeriodsDetails>(item);

                        glPeriodsDetails.setYearId(glPeriodsYears.Id);
                        glPeriodsDetails.setStartDate(item.StartDateStr);
                        glPeriodsDetails.setEndDate(item.EndDateStr);
                        glPeriodsDetails.setStatus(opendStatusId);

                        _ = await _detailRepo.InsertAsync(glPeriodsDetails);
                    }
                    else if (item.Id > 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _detailRepo.DeleteAsync(item.Id);
                    }
                }
            }

            return MapToEntityDto(glPeriodsYears);
        }

        public async Task<GlPeriodsYearsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(d => d.GlPeriodsDetails, x => x.GlCodeComDetails)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<GlPeriodsYearsDto>(current);

            var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetails,_app.Reqlanguage);

            currentDto.codeComUtilityIds = currentCodeCom.ids;
            currentDto.codeComUtilityTexts = currentCodeCom.texts;

            return currentDto;
        }

        public async Task<List<GlPeriodsDetailsDto>> GetAllDetails(long glPeriodsYearsId)
        {
            var output = new List<GlPeriodsDetailsDto>();

            var glPeriodDetailss = await _detailRepo.GetAllIncluding(x => x.FndLookupValues)
                .Where(d => d.GlPeriodsYearsId == glPeriodsYearsId).ToListAsync();

            foreach (var item in glPeriodDetailss)
            {
                var current = new GlPeriodsDetailsDto();

                current.StatusLkp = _app.Reqlanguage.Contains("ar")? item.FndLookupValues.NameAr: item.FndLookupValues.NameEn;
                current.PeriodNameAr = item.PeriodNameAr;
                current.PeriodNameEn = item.PeriodNameEn;
                current.StartDate = item.StartDate;
                current.EndDate = item.EndDate;
                current.StartDateStr = item.StartDate.ToString(Formatters.DateFormat);
                current.EndDateStr = item.EndDate.ToString(Formatters.DateFormat);
                current.StatusLkpId = item.StatusLkpId;
                current.Id = item.Id;

                output.Add(current);
            }

            return output;
        }

        public async Task<bool> GetIsExistingPeriodAsync(string input, string Id)
        {
            var current = await Repository.GetAll().Where(x => x.PeriodYear.ToString() == input && x.Id.ToString() != Id)
                            .FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> UpdateStatusLkp(long statusLkpId, long id)
        {
            var current = await _detailRepo.GetAsync(id);

            try
            {
                var mapped = ObjectMapper.Map(current, new GlPeriodsDetailsDto());

                mapped.StatusLkpId = statusLkpId;

                var entityMapped = ObjectMapper.Map(mapped, current);

                _ = await _detailRepo.UpdateAsync(entityMapped);

                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }

        public async Task<Select2PagedResult> GetGlPeriodsYearsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glPeriodsYearsManager.GetGlPeriodsYearsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetGlPeriodsYearsReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _glPeriodsYearsManager.GetGlPeriodsYearsReportSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
