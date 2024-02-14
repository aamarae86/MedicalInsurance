using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArMiscReceiptHeaders.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ArMiscReceiptHeadersRepository :
        ERPProcedureRepositoryBase<ArMiscReceiptHeaders, long, PostDto, PostOutput>,
        IArMiscReceiptHeadersRepository
    {
        public ArMiscReceiptHeadersRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {
        }

        //public async Task<PostArMiscReceiptHeadersOutput> PostArMiscReceiptHeader(PostArMiscReceiptHeadersDto input)
        //{
        //    await EnsureConnectionOpenAsync();

        //    using (var command = CreateCommand("Execute dbo.ArPostMiscReceipt @ReceiptId,@UserId,@Lang", CommandType.Text, new SqlParameter[] { new SqlParameter("@ReceiptId", input.Id), new SqlParameter("@UserId", input.UserId), new SqlParameter("@Lang", input.Lang) }))
        //    {
        //        using (var dataReader = await command.ExecuteReaderAsync())
        //        {
        //            var result = new PostArMiscReceiptHeadersOutput();

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
