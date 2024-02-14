using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._GlJeHeaders;
using ERP._System._GlJeHeaders.ProcDto;
using ERP._System._GlJeHeaders.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._GlJeHeaders
{
    public class GetGlJeScreenDataRepository :
           ERPProcedureRepositoryBase<GlJeHeaders, long, IdLangInputDto, GlJeScreenDataOutput>,
        IGetGlJeScreenDataRepository
    {

        public GetGlJeScreenDataRepository(
              IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider
          ) : base(dbContextProvider, activeTransactionProvider)
        {
        }

    }
}
