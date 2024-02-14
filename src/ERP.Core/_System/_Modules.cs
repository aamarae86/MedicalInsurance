using ERP._System.__AccountModule._ArReceipts;
using ERP._System._ApBankAccounts;
using ERP._System._ApBanks;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApPdcInterface;
using ERP._System._ApUserBankAccess;
using ERP._System._ArCustomers;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArPdcInterface;
using ERP._System._FndCollectors;
using ERP._System._GlAccDetails;
using ERP._System._GlAccHeaders;
using ERP._System._GlAccounts;
using ERP._System._GlJeHeaders;
using ERP._System._GlMainAccounts;
using ERP._System._GlPeriods;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System
{

    //public static class PermissionModules
    //{
    //    public static Dictionary<string, List<string>> Modules = new Dictionary<string, List<string>>();

    //    static List<string> General = new List<string>();
    //    static List<string> Accounts = new List<string>();
    //    static List<string> Aids = new List<string>();
    //    static List<string> CharityBoxes = new List<string>();
    //    static List<string> HR = new List<string>();
    //    static List<string> PmProperties = new List<string>();
    //    static List<string> SpGuarantees = new List<string>();
    //    static List<string> Warehouses = new List<string>();

    //    public static void InitDictionary()
    //    {
    //        General.Add("Tenants");
    //        General.Add("Users");
    //        General.Add("Roles");
    //        Modules.Add(nameof(General), General);

    //        Accounts.Add("Currencies");
    //        Accounts.Add(nameof(ArCustomers));
    //        Accounts.Add(nameof(ApPdcInterface));
    //        Accounts.Add(nameof(ArPdcInterface));
    //        Accounts.Add(nameof(ApUserBankAccess));
    //        Accounts.Add(nameof(FndCollectors));
    //        Accounts.Add(nameof(ApBanks));
    //        Accounts.Add(nameof(GlAccounts));
    //        Accounts.Add(nameof(GlJeHeaders));
    //        Accounts.Add(nameof(GlMainAccounts));
    //        Accounts.Add(nameof(GlAccHeaders));
    //        Accounts.Add(nameof(GlAccDetails));
    //        Accounts.Add(nameof(GlPeriodsYears));
    //        Accounts.Add(nameof(ArMiscReceiptHeaders));
    //        Accounts.Add(nameof(ArReceipts));
    //        Accounts.Add(nameof(ApMiscPaymentHeaders));
    //        Accounts.Add(nameof(ApBankAccounts));
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());
    //        Accounts.Add(nameof());

    //        Modules.Add(nameof(Accounts), Accounts);
    //        Modules.Add(nameof(Aids), Aids);
    //        Modules.Add(nameof(CharityBoxes), CharityBoxes);
    //        Modules.Add(nameof(HR), HR);
    //        Modules.Add(nameof(PmProperties), PmProperties);
    //        Modules.Add(nameof(SpGuarantees), SpGuarantees);
    //        Modules.Add(nameof(Warehouses), Warehouses);
    //    }
    //}

}
