using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArJobSurveyHd;
using ERP._System.__AccountModule._ArJobSurveyHd.Dto;
using ERP._System.__AccountModule._ArJobSurveyHd.Proc;
using ERP._System.__AccountModule._ArJobSurveyTr;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArJobSurveyHd.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ERP._System._ArJobSurveyHd
{
    [AbpAuthorize]
    public class ArJobSurveyHdAppService : AsyncCrudAppService<ArJobSurveyHd, ArJobSurveyHdDto, long, PagedArJobSurveyHdResultRequestDto, CreateArJobSurveyHdDto, ArJobSurveyHdEditDto>,
        IArJobSurveyHdAppService
    {
        private readonly IRepository<ArJobSurveyTr, long> _repoArJobSurveyTr;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGetrptArJobSurveyPostRepository _repopost;
        private readonly IGetrptArJobSurveyRepository _getrptArJobSurveyRepository;

        public ArJobSurveyHdAppService(IRepository<ArJobSurveyHd, long> repository,
            IGetCounterRepository repoProcCounter,IGetrptArJobSurveyRepository getrptArJobSurveyRepository,
            IRepository<ArJobSurveyTr, long> repoArJobSurveyTr, IGetrptArJobSurveyPostRepository repopost) : base(repository)
        {
            
            _repoArJobSurveyTr = repoArJobSurveyTr;
            _repoProcCounter = repoProcCounter;
            _getrptArJobSurveyRepository = getrptArJobSurveyRepository;
            _repopost = repopost;
            CreatePermissionName = PermissionNames.Pages_ArJobSurveyHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArJobSurveyHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArJobSurveyHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArJobSurveyHd;
        }

        public async override Task<PagedResultDto<ArJobSurveyHdDto>> GetAll(PagedArJobSurveyHdResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.ArJobCardVehicleMakeLkp, x => x.ArJobCardVehicleModelLkp, x => x.ArJobSurveyStatusLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ClaimNo))
                queryable = queryable.Where(q => q.ClaimNo.Contains(input.Params.ClaimNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ClaimDate))
                queryable = queryable.Where(q => q.ClaimDate == DateTimeController.ConvertToDateTime(input.Params.ClaimDate));

            if (input.Params != null && input.Params.ArJobSurveyStatusLkpId != null)
                queryable = queryable.Where(q => q.ArJobSurveyStatusLkpId == input.Params.ArJobSurveyStatusLkpId);

            if (input.Params != null && input.Params.PlateNo != null)
                queryable = queryable.Where(q => q.PlateNo == input.Params.PlateNo);

            if (input.Params != null && input.Params.VehicleModelLkpId != null)
                queryable = queryable.Where(q => q.VehicleModelLkpId == input.Params.VehicleModelLkpId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArJobSurveyHdDto>());

            var PagedResultDto = new PagedResultDto<ArJobSurveyHdDto>()
            {
                Items = data2 as IReadOnlyList<ArJobSurveyHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ArJobSurveyHdDto> Create(CreateArJobSurveyHdDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ArJobSurveyHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };
            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.ClaimNo = result?.FirstOrDefault()?.OutputStr ?? string.Empty;


            var mappObj = ObjectMapper.Map<ArJobSurveyHd>(input);
            await Repository.InsertAsync(mappObj);

            //var current = await base.Create(input);

            //foreach (var item in input.ArJobSurveyTr)
            //{
                 
            //    item.ArJobSurveyHdId = current.Id;

            //    var currentDetail = ObjectMapper.Map<ArJobSurveyTr>(item);
            //    await _repoArJobSurveyTr.InsertAsync(currentDetail);
            //}

            return new ArJobSurveyHdDto();
        }

        public async Task<ArJobSurveyHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.ArJobCardVehicleMakeLkp, x => x.ArJobCardVehicleModelLkp, x => x.ArJobSurveyStatusLkp, x => x.VehicleEmirateLkp, x => x.VehicleColorLkp, x => x.JobTypeLkp, x => x.ArCustomers)
                                       .Where(z => z.Id == input.Id)
                                       .FirstOrDefaultAsync();

            return ObjectMapper.Map<ArJobSurveyHdDto>(current);
        }

        public async Task<IReadOnlyList<ArJobSurveyTrDto>> GetAllArJobSurveyTr(EntityDto<long> input)
        {
            var data = await _repoArJobSurveyTr.GetAllIncluding(x => x.PartsCategoryLkp, x => x.ArJobSurveyPartsList)
                .Where(z => z.ArJobSurveyHdId == input.Id).ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ArJobSurveyTrDto>>(data);
        }

      

        public async override Task<ArJobSurveyHdDto> Update(ArJobSurveyHdEditDto input)
        {
            try
            {

                CheckUpdatePermission();
                var Old = await Repository.GetAsync((long)input.Id);
                ObjectMapper.Map(input, Old);
                _ = await Repository.UpdateAsync(Old);
                // await base.Update(input);

                foreach (var item in input.ArJobSurveyTr)
                {

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var Detail = await _repoArJobSurveyTr.GetAsync((long)item.Id);
                        item.ArJobSurveyHdId = input.Id;
                        ObjectMapper.Map(item, Detail);

                        _ = await _repoArJobSurveyTr.UpdateAsync(Detail);
                   
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.ArJobSurveyHdId = input.Id;
                        var currentDetail = ObjectMapper.Map<ArJobSurveyTr>(item);

                        _ = await _repoArJobSurveyTr.InsertAsync(currentDetail);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArJobSurveyTr.DeleteAsync((long)item.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return new ArJobSurveyHdDto { };
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var Details = await _repoArJobSurveyTr.GetAll().Where(x => x.ArJobSurveyHdId == input.Id).ToListAsync();

            foreach (var item in Details) await _repoArJobSurveyTr.DeleteAsync(item.Id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<PostOutput> PostArJobSurveyHd(GetrptArJobSurveyPostInput postDto)
        {
            try
            {
               // if (AbpSession.UserId.HasValue) { postDto.UserId = AbpSession.UserId.Value; }
                postDto.TenantId = ((int)AbpSession.TenantId);

                var postResult = await _repopost.Execute(postDto, "ArJobSurveyHdPost");

                return postResult.FirstOrDefault();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<GetrptArJobSurveyOutput>> GetrptArJobSurvey(GetrptArJobSurveyInput input)
        {
            input.TenantId = ((int)AbpSession.TenantId);

            var result = await _getrptArJobSurveyRepository.Execute(input, "rptArJobSurvey");

            return result.ToList();
        }
    }
}
