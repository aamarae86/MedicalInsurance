using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersons;
using ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr;
using ERP._System.__HR._HrPersonsAdditionHd.Dto;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonsAdditionHd
{
    public class HrPersonsAdditionHdAppService : AsyncCrudAppService<HrPersonsAdditionHd, HrPersonsAdditionHdDto, long, PagedHrPersonsAdditionHdRequestDto, CreateHrPersonsAdditionHdDto, HrPersonsAdditionHdEditDto>,
        IHrPersonsAdditionHdAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<HrPersonsAdditionTr, long> _repoHrPersonsAdditionTr;
        private readonly IRepository<HrPersons, long> _repoHrPersons;
        private readonly IHrPersonsAdditionPostRepository _hrPersonsAdditionPostRepository;
        public HrPersonsAdditionHdAppService(IRepository<HrPersonsAdditionHd, long> repository,
                  IGetCounterRepository repoProcCounter, IRepository<HrPersonsAdditionTr, long> repoHrPersonsAdditionTr,
                  IHrPersonsAdditionPostRepository hrPersonsAdditionPostRepository,
                  IRepository<HrPersons, long> repoHrPersons)
                  : base(repository)
        {
            _repoProcCounter = repoProcCounter;
            _repoHrPersonsAdditionTr = repoHrPersonsAdditionTr;
            _hrPersonsAdditionPostRepository = hrPersonsAdditionPostRepository;
            _repoHrPersons = repoHrPersons;

            CreatePermissionName = PermissionNames.Pages_HrPersonsAdditionHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonsAdditionHd_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonsAdditionHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonsAdditionHd;
        }

        protected override IQueryable<HrPersonsAdditionHd> CreateFilteredQuery(PagedHrPersonsAdditionHdRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.GlPeriodsDetails, z => z.FndLookupValuesHrPersonsAdditionHdStatusLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AdditionName))
                iqueryable = iqueryable.Where(z => z.AdditionName.Contains(input.Params.AdditionName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AdditionNumber))
            {
                iqueryable = iqueryable.Where(z => z.AdditionNumber.Contains(input.Params.AdditionNumber));
            }

            return iqueryable;
        }

        public async override Task<HrPersonsAdditionHdDto> Create(CreateHrPersonsAdditionHdDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "HrPersonsAdditionHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.AdditionNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;
            input.StatusLkpId = 838;

            var ivAdjustmentHdDto = ObjectMapper.Map<HrPersonsAdditionHd>(input);

            _ = await Repository.InsertAsync(ivAdjustmentHdDto);

            if (input.PersonsAdditionTr.Count > 0)
            {
                foreach (var item in input.PersonsAdditionTr)
                {
                    item.HrPersonAdditionHdId = ivAdjustmentHdDto.Id;

                    var currentAdjustmentTr = ObjectMapper.Map<HrPersonsAdditionTr>(item);

                    _ = await _repoHrPersonsAdditionTr.InsertAsync(currentAdjustmentTr);
                }
            }

            return new HrPersonsAdditionHdDto { };
        }

        public async override Task<HrPersonsAdditionHdDto> Update(HrPersonsAdditionHdEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            if (input.PersonsAdditionTr.Count > 0)
            {
                foreach (var item in input.PersonsAdditionTr)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var propUnits = await _repoHrPersonsAdditionTr.GetAsync((long)item.Id);

                        item.HrPersonAdditionHdId = current.Id;

                        var mapped = ObjectMapper.Map(item, propUnits);

                        _ = await _repoHrPersonsAdditionTr.UpdateAsync(propUnits);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {

                        item.HrPersonAdditionHdId = current.Id;

                        var propUnits = ObjectMapper.Map<HrPersonsAdditionTr>(item);

                        _ = await _repoHrPersonsAdditionTr.InsertAsync(propUnits);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonsAdditionTr.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new HrPersonsAdditionHdDto { };
        }

        public async Task<HrPersonsAdditionHdDto> GetDetailAsync(EntityDto<long> input)
        {
            try
            {
                var current = await Repository
                               .GetAllIncluding(z => z.GlPeriodsDetails, z => z.FndLookupValuesHrPersonsAdditionHdStatusLkp)
                               .Where(z => z.Id == input.Id)
                               .FirstOrDefaultAsync();

                var currentDto = ObjectMapper.Map<HrPersonsAdditionHdDto>(current);
                currentDto.FndLookupValuesHrPersonsAdditionHdStatusLkp.NameAr = current.FndLookupValuesHrPersonsAdditionHdStatusLkp.GetLookupValue();
                return currentDto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task<List<HrPersonsAdditionTrDto>> GetAllAdjustmentTr(EntityDto<long> input)
        {
            var output = new List<HrPersonsAdditionTrDto>();

            var listData = await _repoHrPersonsAdditionTr.GetAllIncluding(z => z.HrPersons, z => z.FndLookupValuesHrPersonsAdditionHdAdditionTypeLkp)
                .Where(d => d.HrPersonAdditionHdId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new HrPersonsAdditionTrDto
                {
                    Id = item.Id,
                    AdditionTypeLkpId = item.AdditionTypeLkpId,
                    HrPersonAdditionHdId = item.HrPersonAdditionHdId,
                    AdditionTypeLkpName =  item.FndLookupValuesHrPersonsAdditionHdAdditionTypeLkp.GetLookupValue()   ,
                    Amount = item.Amount,
                    HrPersonId = item.HrPersonId,
                    HrPersonName = item.HrPersons.GetFullName(),
                    Notes = item.Notes,
                    HrPersonNumber = item.HrPersons.EmployeeNumber,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public override Task Delete(EntityDto<long> input)
        {
            var list = _repoHrPersonsAdditionTr.GetAll().Where(x => x.HrPersonAdditionHdId == input.Id);
            foreach (var item in list)
            {
                _repoHrPersonsAdditionTr.Delete(item);
            }
            return base.Delete(input);
        }

        public async Task<PostOutput> PostHrPersonsAdditionHd(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "HrPersonsAdditionPost");

            return result.FirstOrDefault();
        }

        public async Task<string> GetPersonNumber(EntityDto<long> input)
        {
            var listData = await _repoHrPersons.GetAll()
                .Where(d => d.Id == input.Id).FirstOrDefaultAsync();

            var current = listData == null ? "Not Found" : listData.EmployeeNumber;
            return current;

        }
    }
}
