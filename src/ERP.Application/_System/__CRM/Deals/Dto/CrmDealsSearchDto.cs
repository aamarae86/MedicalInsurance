namespace ERP._System.__CRM._CrmDeals.Dto
{
    public class CrmDealsSearchDto
    {
        public string DealDate { get; set; }
        public string DealName { get; set; }
        public long? DealTypeLkpId { get; set; }
        public long? CrmLeadsPersonsId { get; set; }
        public long? StageLkpID { get; set; }
        public string Lang { get; set; }
        public string Company { get; set; }
        public override string ToString() => $"Params.DealDate={DealDate}&Params.DealName={DealName}&Params.Lang={Lang}&" +
            $"&Params.DealTypeLkpId={DealTypeLkpId}" +
            $"&Params.CrmLeadsPersonsId={CrmLeadsPersonsId}" +
            $"&Params.StageLkpID={StageLkpID}"+
            $"&Params.Company={Company}";
    }
}
