using ERP._System.PostRecords.Dto;

namespace ERP._System.__AccountModule._FaAssetDeprn.Proc
{
    public interface IFaAssetDeprnHdPostRepository :
        IExecuteProcedure<FaAssetDeprnHd, long, PostDto, PostOutput>
    {
    }
}
