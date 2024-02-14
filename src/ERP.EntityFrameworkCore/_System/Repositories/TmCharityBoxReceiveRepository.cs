using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class TmCharityBoxReceiveRepository :
        ERPProcedureRepositoryBase<TmCharityBoxReceive, long, PostDto, PostOutput>
        ,
        ITmCharityBoxReceiveRepository
    {
        public TmCharityBoxReceiveRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
