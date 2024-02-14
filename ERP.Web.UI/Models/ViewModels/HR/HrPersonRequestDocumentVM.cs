using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonRequestDocumentVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(HrPersonRequestDocument.RequestNumber), ResourceType = typeof(HrPersonRequestDocument))]
        public string RequestNumber { get; set; }
        [Display(Name = nameof(HrPersonRequestDocument.RequestTypeId), ResourceType = typeof(HrPersonRequestDocument))]
        public long RequestTypeId { get; set; }
        [Display(Name = nameof(HrPersonRequestDocument.HrPersonId), ResourceType = typeof(HrPersonRequestDocument))]
        public long HrPersonId { get; set; }
        [Display(Name = nameof(HrPersonRequestDocument.StatusLkpId), ResourceType = typeof(HrPersonRequestDocument))]
        public long StatusLkpId { get; set; }
        [Display(Name = nameof(HrPersonRequestDocument.DocRequestDate), ResourceType = typeof(HrPersonRequestDocument))]
        public string DocRequestDate { get; set; }
        [Display(Name = nameof(HrPersonRequestDocument.Notes), ResourceType = typeof(HrPersonRequestDocument))]
        public string Notes { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }
        public DocumentRequestTypeVM DocumentRequestType { get; set; }

        public HrPersonsVM HrPersons { get; set; }

    }
}