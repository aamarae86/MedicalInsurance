using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    [AutoMapTo(typeof(SpBeneficentBanks))]
    public class SpBeneficentBanksCreateDto
    {

        public long BeneficentId { get; set; }

        public long BankLkpId { get; set; }

        public string AccountNumber { get; set; }

        public string AccountOwnerName { get; set; }

        public bool IsDefault { get; set; }
    }
}
