using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmTenants.Dto;

namespace ERP._System.__PmPropertiesModule._PmContract.Dto
{
    [AutoMap(typeof(PmContract))]
    public class ModelForAjaxCall
    {
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public decimal RentAmount { get; set; }
        public PmTenantsDto PmTenants { get; set; }
    }
}
