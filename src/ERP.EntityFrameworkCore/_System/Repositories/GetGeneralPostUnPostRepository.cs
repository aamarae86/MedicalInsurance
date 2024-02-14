using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__AccountModule._GeneralUnPost.Input;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class GetGeneralPostUnPostRepository: ERPProcedureRepositoryBase<GeneralUnPost, long, GeneralPostUnPostInput, PostOutput>
        ,
        IGetGeneralPostUnPostRepository
    {
        public GetGeneralPostUnPostRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
