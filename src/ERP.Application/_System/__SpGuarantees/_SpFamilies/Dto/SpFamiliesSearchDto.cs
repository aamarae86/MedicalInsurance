namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    public class SpFamiliesSearchDto
    {
        public string FamilyName { get; set; }

        public string GuardianName { get; set; }

        public string FamilyNumber { get; set; }

        public string IdNumber { get; set; }

        public string RegistrationDate { get; set; }

        public override string ToString()
            => $"Params.FamilyName={FamilyName}&Params.GuardianName={GuardianName}&Params.FamilyNumber={FamilyNumber}&Params.IdNumber={IdNumber}&Params.RegistrationDate={RegistrationDate}";
    }
}
