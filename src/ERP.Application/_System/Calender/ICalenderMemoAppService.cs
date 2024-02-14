using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.Calender.Dto;
using System.Threading.Tasks;

namespace ERP._System.Calender
{
    public interface ICalenderMemoAppService : IAsyncCrudAppService<CalenderMemoDto, long, CalenderMemoPagedDto, CalenderMemoCreateDto, CalenderMemoEditDto>
    {
    }
}
