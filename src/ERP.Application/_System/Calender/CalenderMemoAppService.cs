using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._GlCodeComDetails;
using ERP._System.Calender.Dto;
using ERP.Core.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.Calender
{
    [AbpAuthorize]
    public class CalenderMemoAppService : AsyncCrudAppService<FndCalendarMemo, CalenderMemoDto, long, CalenderMemoPagedDto, CalenderMemoCreateDto, CalenderMemoEditDto>,
        ICalenderMemoAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        public CalenderMemoAppService(IGlCodeComDetailsManager glCodeComDetailsManager, 
            IRepository<FndCalendarMemo, long> repository) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
        }
        public async  Task<List<CalenderMemoDto>> GetAll2()
        {
            CheckGetAllPermission();
            var res = Repository.GetAll().Where(x => x.UserId == (long)AbpSession.UserId && x.TenantId == AbpSession.TenantId);

            return ObjectMapper.Map<List<CalenderMemoDto>>(res); ;
            

        }
        public async override Task<CalenderMemoDto> Create(CalenderMemoCreateDto input)
        {
            input.UserId = AbpSession.UserId.Value;

            return await base.Create(input);
        }
        public override Task Delete(EntityDto<long> input)
        {
            if (Repository.Count(z => z.Id == input.Id && z.UserId == AbpSession.UserId) > 0)
            {
                return base.Delete(input);
            }
            return null;
        }
     
    }
}
