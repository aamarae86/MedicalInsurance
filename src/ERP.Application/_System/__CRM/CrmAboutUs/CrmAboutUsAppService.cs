
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._CrmAboutUs;
using ERP._System.__CRM._CrmAboutUs.Dto;
using ERP._System.__CRM.AboutUs;
using ERP._System.__CRM.AboutUs.Dto;
using ERP._System._ArCustomers.Dto;
using ERP._System._Counters.ProcDto;

using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CrmAboutUsModule._CrmAboutUs
{
    [AbpAuthorize]
    public class CrmAboutUsAppService : AttachBaseAsyncCrudAppService<CrmAboutUs, CrmAboutUsDto, long, PagedCrmAboutUsResultRequestDto, CrmAboutUsCreateDto, CrmAboutUsEditDto, AttachAuditedEntity>, ICrmAboutUsAppService
    {
        private readonly IRepository<AboutUSSlider, long> _aboutUSSlider;
        private readonly IImageConfig _imageConfig;


        public CrmAboutUsAppService(IRepository<CrmAboutUs, long> repository,
            IRepository<AboutUSSlider, long> aboutUSSlider, IImageConfig imageConfig, IConfiguration config) : base(repository, config)
        {
            _aboutUSSlider = aboutUSSlider;

            CreatePermissionName = PermissionNames.Pages_CrmAboutUs_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmAboutUs_Update;
            DeletePermissionName = PermissionNames.Pages_CrmAboutUs_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmAboutUs;

            PreFileName = "Slider_";
            ServiceFolder = "CrmAboutUs";
        }

        

        protected override IQueryable<CrmAboutUs> CreateFilteredQuery(PagedCrmAboutUsResultRequestDto input)
        {
            try
            {
                var queryable = Repository.GetAll();


                if (!string.IsNullOrEmpty(input.Params.HeaderName))
                    queryable = queryable.Where(o => o.HeaderNameAr.Contains(input.Params.HeaderName)||
                                                     o.HeaderNameEN.Contains(input.Params.HeaderName) );
 
                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (Exception)
            {
                return base.CreateFilteredQuery(input);
            }
        }

 

        public async override Task<CrmAboutUsDto> Create(CrmAboutUsCreateDto input)
        {
            CheckCreatePermission();



            var EntityToAddDto = ObjectMapper.Map<CrmAboutUs>(input);

            _ = await Repository.InsertAsync(EntityToAddDto);

            if (input.AboutUSSliderDtoList.Count() > 0)
            {
                var res = await CRUS_AboutUS_Slider(input.AboutUSSliderDtoList, EntityToAddDto.Id);
            }

            return new CrmAboutUsDto { };
        }

        public async override Task<CrmAboutUsDto> Update(CrmAboutUsEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            if (input.AboutUSSliderDtoList.Count > 0)
            {
                var res = await CRUS_AboutUS_Slider(input.AboutUSSliderDtoList, current.Id);
            }

            return new CrmAboutUsDto { };
        }
         

        public async Task<IEnumerable<AboutUSSliderDto>> GetAllAttachments(EntityDto<long> input)
        {
            var current = await _aboutUSSlider.GetAll()
                .Where(z => z.CrmAboutUsId == input.Id).ToListAsync();        
            return ObjectMapper.Map<IEnumerable<AboutUSSliderDto>>(current);
        }

        public override Task Delete(EntityDto<long> input)
        {
            var list = _aboutUSSlider.GetAll().Where(x => x.CrmAboutUsId == input.Id);
            foreach (var item in list)
            {
                _aboutUSSlider.Delete(item);
            }
            return base.Delete(input);
        }



        public async Task<bool> CRUS_AboutUS_Slider(IEnumerable<AboutUSSliderDto> model, long CrmAboutUsId)
        {
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var entity = await _aboutUSSlider.GetAsync(item.Id);

                        item.CrmAboutUsId = CrmAboutUsId;

                        var mapped = ObjectMapper.Map(item, entity);

                        _ = await _aboutUSSlider.UpdateAsync(entity);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.CrmAboutUsId = CrmAboutUsId;
                        var entity = ObjectMapper.Map<AboutUSSlider>(item);
                        _ = await _aboutUSSlider.InsertAsync(entity);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _aboutUSSlider.DeleteAsync(item.Id);
                    }
                }

                return true;
            }

            return false;

        }




        //private string GetFilePath(string base64, string fileExtension = ".jpeg")
        //    => _imageConfig.SaveImage(base64, $"PmProp-Attchs-{Guid.NewGuid().ToString()}", fileExtension, "AppAttachments/CrmAboutUs");
    }
}
