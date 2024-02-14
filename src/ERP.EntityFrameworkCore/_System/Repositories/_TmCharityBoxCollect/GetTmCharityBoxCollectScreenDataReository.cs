using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__CharityBoxes._TmCharityBoxCollect;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._TmCharityBoxCollect
{
    public class GetTmCharityBoxCollectScreenDataReository :
           ERPProcedureRepositoryBase<TmCharityBoxCollect, long, IdLangInputDto, TmCharityBoxCollectScreenDataOutput>,
        IGetTmCharityBoxCollectScreenDataReository
    {
        public GetTmCharityBoxCollectScreenDataReository(
                    IDbContextProvider<ERPDbContext> dbContextProvider,
                    IActiveTransactionProvider activeTransactionProvider
                ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
