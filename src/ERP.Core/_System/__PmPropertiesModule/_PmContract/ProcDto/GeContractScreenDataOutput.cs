using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContract.ProcDto
{
    public class GeContractScreenDataOutput
    {
        public string OwnerName { get; set; }
        public string OwnerNationalityName { get; set; }
        public string OwnerIdNumber { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerHomePhoneNumber { get; set; }
        public string OwnerPoBox { get; set; }
        public string OwnerEmailAddress { get; set; }
        public string TenantName { get; set; }
        public string TenantNationalityName { get; set; }
        public string TenantIdNumber { get; set; }
        public string TenantHomePhoneNumber { get; set; }
        public string TenantAddress { get; set; }
        public string TenantEmailAddress { get; set; }
        public string Region { get; set; }
        public string UnitNo { get; set; }
        public string ElectricityNumber { get; set; }
        public string PropertiesAddress { get; set; }
        public string UnitTypeName { get; set; }
        public string PropertyName { get; set; }
        public string Notes { get; set; }
        public string FloorLevel { get; set; }
        public string LandNumber { get; set; }
        public string ActivityName { get; set; }
        public string RentPeriod { get; set; }
        public string PmUnitDesc { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal RentAMOUNT { get; set; }
        public decimal InsuranceAmount { get; set; }
        public string AreaSize { get; set; }
        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string Condition5 { get; set; }
        public long Id { get; set; }
        public string DType { get; set; }
        public string RNumber { get; set; }
        public string PayType { get; set; }
        public string PayNumber { get; set; }
        public DateTime PayDate { get; set; }
    }
}
