namespace ERP._System._GlPeriods.Dto
{
    public class GlPeriodsYearsSearchDto
    {
        public string PeriodYear { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public override string ToString()
        {
            return $"Params.PeriodYear={PeriodYear}&Params.StartDate={StartDate}&Params.EndDate={EndDate}";
        }
    }
}
