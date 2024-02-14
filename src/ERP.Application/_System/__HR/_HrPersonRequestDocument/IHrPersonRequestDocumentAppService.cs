using Abp.Application.Services;
using ERP._System.__HR._HrPersonRequestDocument.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument
{
  public  interface IHrPersonRequestDocumentAppService : IAsyncCrudAppService<HrPersonRequestDocumentDto, long, HrPersonRequestDocumentPagedDto, HrPersonRequestDocumentCreateDto, HrPersonRequestDocumentEditDto>
    {
    
    
    }
}
