using ERP._System.PostRecords.Dto;

namespace ERP._System.__AccountModuleExtend._FaAssets.Proc
{
    public interface IFaAssetsPostRepository :
        IExecuteProcedure<FaAssets, long, PostDto, PostOutput>
    {
    }
}
