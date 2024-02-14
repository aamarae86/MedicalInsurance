using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using ERP._System.__AccountModuleExtend._FaAssets.Dto;
using ERP._System.__AccountModuleExtend._FaAssets.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._FaAssets
{
    public interface IFaAssetsAppService : IAsyncCrudAppService<FaAssetDto, long, FaAssetPagedDto, FaAssetCreateDto, FaAssetEditDto>
    {
        Task<Select2PagedResult> GetSelect2WithCategoryExcludingIds(string categoryId, string ids, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<PostOutput> PostFaAsset(PostDto idLangInputDto);
    }
}
