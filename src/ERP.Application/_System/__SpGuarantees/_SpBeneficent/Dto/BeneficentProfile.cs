using AutoMapper;
//using ERP._System.__SpGuarantees._ScPortalRequestStudy.Dto;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    public class BeneficentProfile : Profile
    {
        public BeneficentProfile()
        {
            CreateMap<SpBeneficentBanks, SpBeneficentBanksDto>()
                .ForMember(b => b.BankNameAr, options => options.MapFrom(e => e.LookupBankValues.NameAr))
                .ForMember(b => b.BankNameEn, options => options.MapFrom(e => e.LookupBankValues.NameEn))
                .ReverseMap();
            CreateMap<SpBeneficentDto, SpBeneficent>()
                .ForMember(b => b.BeneficentNumber, opt => opt.Ignore());
            CreateMap<SpBeneficentBanks, SpBeneficentBankEditDto>()
                .ForMember(d => d.BeneficentId, options => options.MapFrom(s => s.SpBeneficentId))
                .ReverseMap();
            CreateMap<SpBeneficentBanks, SpBeneficentBanksCreateDto>()
                .ForMember(d => d.BeneficentId, options => options.MapFrom(s => s.SpBeneficentId))
                .ReverseMap();
            CreateMap<SpBeneficentAttachments, SpBeneficentAttachmentsDto>()
                .ForMember(d => d.BeneficentId, options => options.MapFrom(s => s.SpBeneficentId))
                .ReverseMap();
        }
    }
}
