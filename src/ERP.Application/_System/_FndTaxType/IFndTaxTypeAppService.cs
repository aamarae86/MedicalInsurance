using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._FndTaxType
{
    public interface IFndTaxTypeAppService : IAsyncCrudAppService<FndTaxTypeDto, long, FndTaxTypePagedDto, FndTaxTypeCreateDto, FndTaxTypeEditDto>
    {
    }
}
