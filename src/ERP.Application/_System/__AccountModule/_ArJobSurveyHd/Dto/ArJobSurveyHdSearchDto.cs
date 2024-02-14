namespace ERP._System._ArJobSurveyHd.Dto
{
    public class ArJobSurveyHdSearchDto
    {
        public string ClaimNo { get; set; }
        public string ClaimDate { get; set; }
        public string PlateNo { get; set; }
        public long? ArJobSurveyStatusLkpId { get; set; }
        public long? VehicleModelLkpId { get; set; }
        
        public override string ToString() => $"Params.ClaimNo={ClaimNo}&Params.ClaimDate={ClaimDate}&Params.ArJobSurveyStatusLkpId={ArJobSurveyStatusLkpId}&Params.VehicleModelLkpId={VehicleModelLkpId}&Params.PlateNo={PlateNo}";
    }
}
