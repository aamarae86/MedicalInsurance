using ERP._System.PostRecords.Dto;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive
{
    public interface ITmCharityBoxReceiveRepository : IExecuteProcedure<TmCharityBoxReceive, long, PostDto, PostOutput>
    {
    }

}
