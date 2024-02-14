using ERP._System.__CharityBoxes._TmLocations.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmLocationsVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(TmLocations.RegionId), ResourceType = typeof(TmLocations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long RegionId { get; set; }

        public TmRegionsVM Region { get; set; }

        [Display(Name = nameof(TmLocations.LocationNumber), ResourceType = typeof(TmLocations))]
        [MaxLength(30)]
        public string LocationNumber { get; set; }

        [Display(Name = nameof(TmLocations.LocationName), ResourceType = typeof(TmLocations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("GetExistLocationNameAsync", "TmLocations", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string LocationName { get; set; }

        [Display(Name = nameof(TmLocations.SubLocationNumber), ResourceType = typeof(TmLocations))]
        [MaxLength(30)]
        public string SubLocationNumber { get; set; }

        [Display(Name = nameof(TmLocations.SubLocationName), ResourceType = typeof(TmLocations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string SubLocationName { get; set; }

        [Display(Name = nameof(TmLocations.Notes), ResourceType = typeof(TmLocations))]
        [MaxLength(30)]
        public string SubLocationNotes { get; set; }

        public ICollection<TmLocationSubDto> InputCollection
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(ListOfSubLocationsStr) ?
                     new List<TmLocationSubDto>() : Helper<List<TmLocationSubDto>>.Convert(ListOfSubLocationsStr);
                }
                catch (Exception x) { throw; }
            }
        }

        public ICollection<TmLocationSubDto> LocationSubs { get; set; }
        public string ListOfSubLocationsStr { get; set; }
    }
}