using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._TmDamagedCharityBoxs
{
    public class GetTmDamagedCharityBoxesScreenDataRepository :
           ERPProcedureRepositoryBase<TmDamagedCharityBoxs, long, IdLangInputDto, TmDamagedCharityBoxesScreenDataOutput>,
        IGetTmDamagedCharityBoxesScreenDataRepository
    {
        public GetTmDamagedCharityBoxesScreenDataRepository(
                    IDbContextProvider<ERPDbContext> dbContextProvider,
                    IActiveTransactionProvider activeTransactionProvider
                ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
