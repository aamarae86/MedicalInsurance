using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._GlJeHeaders;
using ERP._System._GlJeHeaders.ProcDto;
using ERP._System._GlJeHeaders.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._GlJeHeaders
{
    public class GetJeNumberRepository:
        ERPProcedureRepositoryBase<GlJeHeaders, long, JeNumberPostDto, StringOutput>,
        IJeNumberRepository
    {
        public GetJeNumberRepository
           (
               IDbContextProvider<ERPDbContext> dbContextProvider,
               IActiveTransactionProvider activeTransactionProvider
           ) :  base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
