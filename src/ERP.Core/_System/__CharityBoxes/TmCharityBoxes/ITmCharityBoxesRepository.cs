using ERP._System.PostRecords.Dto;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    public interface ITmCharityBoxesRepository : IExecuteProcedure<TmCharityBoxes, long, PostDto, TransOutput>
    {
    }

}
