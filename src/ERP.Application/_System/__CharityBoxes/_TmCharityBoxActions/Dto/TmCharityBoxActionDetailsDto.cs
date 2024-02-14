using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    [AutoMap(typeof(TmCharityBoxActionDetails))]
    public class TmCharityBoxActionDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public string Notes { get;  set; }

        public long ActionLkpId { get;  set; }

        public string ActionLkp{ get;  set; }

        public long StatusLkpId { get;  set; }

        public long TmLocationSubId { get;  set; }

        public string TmLocationSubTxt { get;  set; }

        public long? OldCharityBoxid { get;  set; }

        public string OldCharityBox { get;  set; }

        public long? NewCharityBoxId { get;  set; }

        public string NewCharityBox { get;  set; }

        public long CharityBoxActionId { get;  set; }

        public string rowStatus { get; set ; }
    }
}
