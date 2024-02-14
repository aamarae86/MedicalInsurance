using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive
{
    public interface ITmCharityBoxReceiveAppService : IAsyncCrudAppService<TmCharityBoxReceiveDto, long, PagedTmCharityBoxReceiveResultRequestDto, CreateTmCharityBoxReceiveDto, TmCharityBoxReceiveEditDto>
    {
        Task<TmCharityBoxReceiveDto> GetDetailAsync(EntityDto<long> input);
        Task<PostOutput> PostTmCharityBoxReceive(PostDto idLangInputDto);

        //Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
