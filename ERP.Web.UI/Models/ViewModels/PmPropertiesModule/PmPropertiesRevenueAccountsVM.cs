using Abp.Domain.Entities;
using ERP.ResourcePack.PmPropertiesModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmPropertiesRevenueAccountsVM : Entity<long>
    {
        [Display(Name = nameof(PmProperties.Percentage), ResourceType = typeof(PmProperties))]
        public decimal Percentage { get;  set; }
    }
}