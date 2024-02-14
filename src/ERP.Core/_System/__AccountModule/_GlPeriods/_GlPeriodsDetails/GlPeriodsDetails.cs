using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._FaAssetDeprn;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._PyPayrollOperations;
using ERP._System.__SpGuarantees._SpPayments;
using ERP._System._FndLookupValues;
using ERP._System._GlJeHeaders;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlPeriods
{
    public class GlPeriodsDetails : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(200)]
        public string PeriodNameEn { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PeriodNameAr { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public long GlPeriodsYearsId { get; protected set; }

        [ForeignKey(nameof(GlPeriodsYearsId))]
        public GlPeriodsYears GlPeriodsYears { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        public virtual ICollection<GlJeHeaders> GlJeHeaders { get; protected set; }
        public virtual ICollection<HrPersonsAdditionHd> HrPersonsAdditionHd { get; protected set; }

        public virtual ICollection<HrPersonsDeductionHd> HrPersonsDeductionHd { get; protected set; }

        [InverseProperty(nameof(HrPersonSalaryElements.StartPeriods))]
        public virtual ICollection<HrPersonSalaryElements> HrPersonSalaryStartPeriods { get; protected set; }

        [InverseProperty(nameof(HrPersonSalaryElements.EndPeriods))]
        public virtual ICollection<HrPersonSalaryElements> HrPersonSalaryEndPeriods { get; protected set; }

        public virtual ICollection<PyPayrollOperations> PyPayrollOperations { get; protected set; }

        public virtual ICollection<FaAssetDeprnHd> FaAssetDeprnHd { get; protected set; }

        public virtual ICollection<SpCasesPaymentDeserving> SpCasesPaymentDeserving { get; protected set; }

        public virtual ICollection<GlJeIntegrationHeaders> GlJeIntegrationHeaders { get; protected set; }

        [InverseProperty(nameof(SpPayments.FromPeriod))]
        public virtual ICollection<SpPayments> SpPaymentsFromPeriod { get; protected set; }

        [InverseProperty(nameof(SpPayments.ToPeriod))]
        public virtual ICollection<SpPayments> SpPaymentsToPeriod { get; protected set; }

        public virtual ICollection<SpPaymentPersonDetails> SpPaymentPersonDetails { get; protected set; }

        public int TenantId { get; set; }

        #endregion

        protected GlPeriodsDetails() { }

        public void setYearId(long id)
        {
            GlPeriodsYearsId = id;
        }

        public void setStatus(long id)
        {
            StatusLkpId = id;
        }

        public void setStartDate(string sDate) => StartDate = DateTimeController.ConvertToDateTime(sDate) ?? DateTime.MinValue;

        public void setEndDate(string eDate) => EndDate = DateTimeController.ConvertToDateTime(eDate) ?? DateTime.MinValue;
    }
}
