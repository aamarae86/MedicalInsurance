using ERP.Users.Dto;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScCampainsDetailDeliverVM : BasePostAuditedVM<long>
    {
        public long CampainId { get; set; }
        public long PortalFndUsersId { get; set; }
        public long PortalFndUsersId1 { get; set; }
        public string CampainName { get; set; }
        public string HelpKind { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long CampainAidId { get; set; }
        public long StatusLkpId { get; set; }
        public string ScCampainsDate => ScCampains.ScCampainDate;
        public ScCampainsVM ScCampains { get; set; }
        public PortalUserDto PortalFndUsers { get; set; }
        public ScCampainsAidVM ScCampainsAid { get; set; }
        public FndLookupValuesVM FndLookupValues { get; set; }
    }
}