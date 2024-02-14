using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAids.Input
{
    public class GeSCCasesListScreenDataInput
    {
        public string IdNumber { get; set; }
        public long? CityLkpId { get; set; }
        public long? NationalityLkpId { get; set; }
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public bool IsZakat { get; set; }
    }

    public class GeSCCasesListScreenDataInputHelper
    {
        public string IdNumber { get; set; }
        public long? CityLkpId { get; set; }
        public string CityLkpIdtxt { get; set; }
        public long? NationalityLkpId { get; set; }
        public string NationalityLkpIdtxt { get; set; }
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public bool IsZakat { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&IdNumber={IdNumber}&CityLkpId={CityLkpId}&NationalityLkpId={NationalityLkpId}&TenantId={TenantId}&IsZakat={IsZakat}";
        }
    }
}
