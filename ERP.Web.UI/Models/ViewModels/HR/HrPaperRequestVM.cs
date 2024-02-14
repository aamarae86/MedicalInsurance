using ERP._System.__HR._HrPaperRequest.Dto;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPaperRequestVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        public string PaperReqNumber { get; set; }
        public string PaperReqDate { get; set; }
        public long HrPersonId { get; set; }
        public List<long> HrPersonIds { get; set; }
        public string ReqDetails { get; set; }
        public string FilePath { get; set; }
        public long PaperReqTypeId { get; set; }

        public HrPersonsVM HrPersons { get; set; }

        public PaperReqTypeVM PaperReqType { get; set; }
        public string rowStatus { get; set; }

        public string HrPaperRequestAttachmentdetailsListStr { get; set; }
        public ICollection<HrPaperRequestAttachmentDto> HrPaperRequestAttachmentdetails => string.IsNullOrEmpty(HrPaperRequestAttachmentdetailsListStr) ?
                new List<HrPaperRequestAttachmentDto>() : Helper<List<HrPaperRequestAttachmentDto>>.Convert(HrPaperRequestAttachmentdetailsListStr);


    }
}