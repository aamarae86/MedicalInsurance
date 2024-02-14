using Abp.Application.Services.Dto;

namespace ERP._System.Calender.Dto
{
    public class CalenderMemoEditDto : EntityDto<long>
    {
        public string Memo { get; set; }
        public string MemoDate { get; set; }
    }
}
