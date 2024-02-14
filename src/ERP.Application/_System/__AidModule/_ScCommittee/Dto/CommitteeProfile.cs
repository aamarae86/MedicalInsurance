using AutoMapper;
using ERP._System._GlCodeComDetails;
using ERP._System._ScComityMembers;
using ERP._System._ScComityMembers.Dto;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    public class CommitteeProfile : Profile
    {
        public IGlCodeComDetailsManager glCodeComDetailsManager { get; set; }

        public CommitteeProfile(/*IGlCodeComDetailsManager glCodeComDetailsManager*/)
        {
            CreateMap<ScCommitteeDetail, ScCommitteeDetailDto>()
                    .ForMember(d => d.CodeComUtilityTexts,
                    options => options.MapFrom(s => glCodeComDetailsManager.GetCodeComTextsIds(s.RequestStudy.GlCodeComDetails, "ar-EG").Result.texts))
                    .ForMember(d => d.PortalRequestNumber,
                    options => options.MapFrom(s => s.RequestStudy.ScPortalRequest.PortalRequestNumber))
                    .ForMember(d => d.PortalRequestEncId,
                    options => options.MapFrom(d => CipherStringController.Encrypt(d.RequestStudy.ScPortalRequest.Id.ToString())))
                    .ForMember(d => d.RequestStudyEncId,
                    options => options.MapFrom(d => CipherStringController.Encrypt(d.RequestStudy.Id.ToString())))
                    .ForMember(d => d.Name,
                    options => options.MapFrom(d => d.RequestStudy.ScPortalRequest.Name))
                    .ForMember(d => d.IdNumber,
                    options => options.MapFrom(d => d.RequestStudy.ScPortalRequest.IdNumber))
                    .ReverseMap();



            CreateMap<ScCommitteeMemberDetail, ScCommitteeMemberDetailDto>()
                .ForMember(d => d.MemberNumber,
                options => options.MapFrom(s => s.Member.MemberNumber))
                .ForMember(d => d.MemberName,
                options => options.MapFrom(s => s.Member.MemberName))
                .ForMember(d => d.MemberCategoryAr,
                options => options.MapFrom(s => s.Member.FndLookupValues.NameAr))
                .ForMember(d => d.MemberCategoryEn,
                options => options.MapFrom(s => s.Member.FndLookupValues.NameEn))
                .ReverseMap();


            CreateMap<ScComityMembers, ScComityMembersDto>()
               .ForMember(d => d.MemberCategoryAr, options => options.MapFrom(s => s.FndLookupValues.NameAr))
               .ForMember(d => d.MemberCategoryEn, options => options.MapFrom(s => s.FndLookupValues.NameEn))
               ;

            CreateMap<ScCommitteeDetailsElectronicAidDto, ScCommitteeDetailsElectronicAid>();

            CreateMap<ScCommitteeDetailsElectronicAid, ScCommitteeDetailsElectronicAidDto>()
               .ForMember(d => d.ElectronicTypeLkpNameAr, options => options.MapFrom(s => s.FndElectronicTypeLkp.NameAr))
               .ForMember(d => d.ElectronicTypeLkpNameEn, options => options.MapFrom(s => s.FndElectronicTypeLkp.NameEn))
               ;
        }
    }
}
