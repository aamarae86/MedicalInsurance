
namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    public class ArJobCardHdSearchDto
    {
        public string JobNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public string ClaimNo { get; set; }
        public string JobDate { get; set; }
        public string VehiclePlateNo { get; set; }
        public string LpoNo { get; set; }
        public long? JobTypeLkpId { get; set; }
        public long? VehicleEmirateLkpId { get; set; }
        public long? VehicleColorLkpId { get; set; }
        public long? ArCustomerId { get; set; }
        public long? VehicleMakeLkpId { get; set; }
        public long? VehicleModelLkpId { get; set; }
        public string VehicleType { get; set; }

        public override string ToString()
           => $"Params.JobNumber={JobNumber}&Params.StatusLkpId={StatusLkpId}&Params.ClaimNo={ClaimNo}&Params.JobDate={JobDate}&Params.VehiclePlateNo={VehiclePlateNo}"+
            $"&Params.LpoNo={LpoNo}&Params.JobTypeLkpId={JobTypeLkpId}&Params.VehicleEmirateLkpId={VehicleEmirateLkpId}&Params.VehicleColorLkpId={VehicleColorLkpId}&Params.ArCustomerId={ArCustomerId}"+
            $"&Params.VehicleMakeLkpId={VehicleMakeLkpId}&Params.VehicleModelLkpId={VehicleModelLkpId}&Params.VehicleType={VehicleType}";
    }
}
