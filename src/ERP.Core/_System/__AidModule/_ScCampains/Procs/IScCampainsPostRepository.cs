using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScCampains.Procs
{
    public interface IScCampainsPostRepository : IExecuteProcedure<ScCampains, long, PostDto, PostOutput>
    {
    }
}
