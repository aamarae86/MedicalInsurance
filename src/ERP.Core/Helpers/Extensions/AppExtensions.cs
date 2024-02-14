using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlAccDetails;
using ERP._System._GlAccHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Core.Helpers.Extensions
{
    public static class _app
    {
        public static string Reqlanguage { get; set; }

        public static List<int> FreeModule;

        public static bool IsSubscriptionValid = false;

    }
    public static class AppExtensions
    {
        public static string GetLookupValue(this FndLookupValues entity)
        {
            string ReturnVal = "";
            if(entity == null)
                return ReturnVal;

            if (_app.Reqlanguage.Contains("ar"))
            {
                Console.WriteLine("Curren Language Is Arabic");
                ReturnVal = entity.NameAr;
            }
            else if (_app.Reqlanguage.Contains("en"))
            {
                Console.WriteLine("Curren Language Is English");
                ReturnVal = entity.NameEn;
            } 
            else if (_app.Reqlanguage.Contains("fr"))
            {
                Console.WriteLine("Curren Language Is Frinsh");
                ReturnVal = "Not Impelemented Language";
            }
            else
            {
                Console.WriteLine("Not Matched language");
                ReturnVal = entity.NameAr;
            }

            return ReturnVal;
        }

        public static bool CanEditGlAccHeaders(this GlAccHeaders entity)
        {
            if (entity.GlAccDetails?.Count()>0)
            {
                foreach (var item in entity.GlAccDetails)
                {
                    if (item.GlAccDetailsAttr1Collection.Any() ||
                        item.GlAccDetailsAttr2Collection.Any() ||
                        item.GlAccDetailsAttr3Collection.Any() ||
                        item.GlAccDetailsAttr4Collection.Any() ||
                        item.GlAccDetailsAttr5Collection.Any() ||
                        item.GlAccDetailsAttr6Collection.Any() ||
                        item.GlAccDetailsAttr7Collection.Any() ||
                        item.GlAccDetailsAttr8Collection.Any() ||
                        item.GlAccDetailsAttr9Collection.Any() )
                    {
                        return false;
                    }
                }    
            }
            return true;

        }

        public static bool CanEditGlAccDetails(this GlAccDetails entity)
        {
            if ( entity.GlAccDetailsAttr1Collection.Any() || 
                 entity.GlAccDetailsAttr2Collection.Any() ||
                 entity.GlAccDetailsAttr3Collection.Any() ||
                 entity.GlAccDetailsAttr4Collection.Any() ||
                 entity.GlAccDetailsAttr5Collection.Any() ||
                 entity.GlAccDetailsAttr6Collection.Any() ||
                 entity.GlAccDetailsAttr7Collection.Any() ||
                 entity.GlAccDetailsAttr8Collection.Any() ||
                 entity.GlAccDetailsAttr9Collection.Any() )
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public static int ClculateRemainingDays(this DateTime ExpDate)
        {
            if (ExpDate.Date < DateTime.Now.Date)
            {
                return 0;
            }
            else
            {
                var days= (ExpDate.Date - DateTime.Now.Date).Days + 1;
                return days;
            }
        }

        public static DateTime CalculateNewSubEndDate(this DateTime? date,int NOfMonthes)
        {
            DateTime NewSubEndDate;
            if (!date.HasValue)
            {
                NewSubEndDate = DateTime.Now.Date.AddMonths(NOfMonthes);
            }
            else if (date.HasValue && date.Value.Date.ClculateRemainingDays() < 0)
            {
                NewSubEndDate = DateTime.Now.Date.AddMonths(NOfMonthes);
            }
            else //if (date.HasValue && date.Value.Date.ClculateRemainingDays() > 0)
            {
                NewSubEndDate = date.Value.Date.AddMonths(NOfMonthes);
            }

            return NewSubEndDate;
        }



    }


}
