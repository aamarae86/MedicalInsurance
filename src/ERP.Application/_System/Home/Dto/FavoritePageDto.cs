using Abp.Application.Services.Dto;
using AutoMapper;

namespace ERP._System.Home.Dto
{
    public class FavoritePageDto : EntityDto<long>
    {
        public int PageId { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public string PageSelector { get; set; }

        public string PageNameAr { get; set; }

        public string PageNameEn { get; set; }
        public long? UserId { get; internal set; }
    }
}
