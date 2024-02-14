using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._GlJeHeaders;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GlJeHeadersRepository :
        ERPProcedureRepositoryBase<GlJeHeaders, long, PostDto, PostOutput>,
        IGlJeHeadersRepository
    {
        public GlJeHeadersRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {
        }

        //public async Task<PostGlJeHeadersOutput> PostGlJeHeader(PostGlJeHeadersDto input)
        //{
        //    await EnsureConnectionOpenAsync();

        //    using (var command = CreateCommand("Execute dbo.GlPostJe @jeId,@UserId,@Lang", CommandType.Text, new SqlParameter[] { new SqlParameter("@jeId", input.Id), new SqlParameter("@UserId", input.UserId), new SqlParameter("@Lang", input.Lang) }))
        //    {
        //        using (var dataReader = await command.ExecuteReaderAsync())
        //        {
        //            var result = new PostGlJeHeadersOutput();

        //            while (dataReader.Read())
        //            {
        //                result.FinalStatues = dataReader["FinalStatues"].ToString();
        //                result.Reason = dataReader["Reason"].ToString();
        //            }

        //            return result;
        //        }
        //    }
        //}
    }
}
