using ERP._System.__CRM._CrmLeadsPersons.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.CRM.Leads;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.CRM
{
    public class CrmQueriesController : BaseController
    {
        public CrmQueriesController() : base("CrmQueries", PermissionNames.Pages_CrmQueries)
        { }
        public PartialViewResult CrmQueriesSearch() => PartialView();

        public PartialViewResult CrmQueriesData() => PartialView();

        public async Task<ActionResult> LoadDataGrid(CrmLeadsPersonsSearchDto searchParms)
        {
            searchParms.IsLead = 1;
            searchParms.Lang = Thread.CurrentThread.CurrentCulture.Name;
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);
            var Lang = Thread.CurrentThread.CurrentCulture.Name; //ar-EG

            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;


            var parameters = new GetAllPagedAndSortedWithParams<CrmLeadsPersonsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"CrmLeadsPersons/GetCrmQueries", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<CrmLeadsPersonsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<CrmLeadsPersonsVM>();
            //int recordsTotal = dataConverted?.Count() ?? 0;
            //var data = dataConverted ?? new List<CrmLeadsPersonsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

    }
}
