using ERP._System.__AccountModuleExtend._GlAccMapping.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class GlAccMappingHdVM : BaseAuditedEntityVM<long>
    {
        #region Hd
        public string EncId { get; set; }

        [Display(Name = nameof(GlAccMapping.MapName), ResourceType = typeof(GlAccMapping))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string MapName { get; set; }

        [Display(Name = nameof(GlAccMapping.MapNumber), ResourceType = typeof(GlAccMapping))]
        public string MapNumber { get; set; }

        public string GlAccMappingTrListStr { get; set; }
        public ICollection<GlAccMappingTrDto> GlAccMappingTrList
         => string.IsNullOrEmpty(GlAccMappingTrListStr) ? new List<GlAccMappingTrDto>() : Helper<List<GlAccMappingTrDto>>.Convert(GlAccMappingTrListStr);

        #endregion

        #region Tr
        [MaxLength(200)]
        [Display(Name = nameof(GlAccMapping.TrName), ResourceType = typeof(GlAccMapping))]
        public string TrName { get; set; }

        [Display(Name = nameof(GlAccMapping.TrNo), ResourceType = typeof(GlAccMapping))]
        public long? TrNo { get; set; }

        #endregion

        #region TrDtl

        [Display(Name = nameof(GlAccMapping.TypeLkpId), ResourceType = typeof(GlAccMapping))]
        public long? TypeLkpId { get; set; }

        [Display(Name = nameof(GlAccMapping.FromAccId), ResourceType = typeof(GlAccMapping))]
        public long? FromAccId { get; set; }

        [Display(Name = nameof(GlAccMapping.ToAccId), ResourceType = typeof(GlAccMapping))]
        public long? ToAccId { get; set; }

        public string FromAccDescriptionAr { get; set; }

        public string FromAccDescriptionEn { get; set; }

        public string ToAccDescriptionAr { get; set; }

        public string ToAccDescriptionEn { get; set; }

        public long GlAccMappingTrId { get; set; }

        #endregion
    }
}