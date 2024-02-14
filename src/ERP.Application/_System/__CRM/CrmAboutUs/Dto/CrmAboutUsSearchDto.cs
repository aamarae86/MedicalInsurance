using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmAboutUs.Dto
{
    public class CrmAboutUsSearchDto : EntityDto<long>
    {
        public string HeaderName { get; set; }


        public override string ToString()
        {
            return $"Params.HeaderName={HeaderName}";
        }
    }
}
