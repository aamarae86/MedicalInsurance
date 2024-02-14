namespace ERP._System.__AidModule._ScCampains.Dto
{
    public class MasterDetailSearchDto
    {
        public long? portalFndUsersId1 { get; set; }

        public long? portalFndUsersId2 { get; set; }

        public long? campainAidId { get; set; }

        public long? statusLkpId { get; set; }

        public string CampainName { get; set; }

        public string FromScCampainDate { get; set; }

        public string ToScCampainDate { get; set; }

        public override string ToString() => $"Params.CampainName={CampainName}&Params.portalFndUsersId1={portalFndUsersId1}&Params.portalFndUsersId2={portalFndUsersId2}&Params.campainAidId={campainAidId}&Params.statusLkpId={statusLkpId}&Params.FromScCampainDate={FromScCampainDate}&Params.ToScCampainDate={ToScCampainDate}";
    }
}
