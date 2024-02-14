using Abp.Application.Services.Dto;

namespace ERP._System.PostRecords.Dto
{
    public class PostDto : EntityDto<long>
    {
        public long UserId { get; set; }

        public string Lang { get; set; }
    }

}
