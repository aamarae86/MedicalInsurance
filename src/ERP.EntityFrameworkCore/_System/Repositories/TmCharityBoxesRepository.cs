using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class TmCharityBoxesRepository :
        ERPProcedureRepositoryBase<TmCharityBoxes, long, PostDto, TransOutput>
        ,
        ITmCharityBoxesRepository
    {
        public TmCharityBoxesRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
