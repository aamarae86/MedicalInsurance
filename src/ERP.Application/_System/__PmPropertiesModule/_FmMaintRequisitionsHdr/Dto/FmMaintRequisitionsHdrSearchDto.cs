namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto
{
    public class FmMaintRequisitionsHdrSearchDto
    {
        public string RequisitionNumber { get; set; }

        public string RequisitionDate { get; set; }

        public long? PmPropertiesId { get; set; }

        public long? RequisitionStatusLkpId { get; set; }

        public override string ToString()
            => $"Params.RequisitionNumber={RequisitionNumber}&Params.RequisitionDate={RequisitionDate}&Params.PmPropertiesId={PmPropertiesId}&Params.RequisitionStatusLkpId={RequisitionStatusLkpId}";
    }
}
