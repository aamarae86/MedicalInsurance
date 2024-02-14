using ERP.Front.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace ERP.Front.Helpers.DataTableHelpers
{
    public static class DataTableParmsHelper
    {
        public static DataTableModelParms GetParms(NameValueCollection fc,string defSort = "Id")
        {
            string draw = fc.GetValues("draw") == null ? "1" : fc.GetValues("draw").FirstOrDefault();
            string start = fc.GetValues("start") == null ? "0" : fc.GetValues("start").FirstOrDefault();
            string length = fc.GetValues("length") == null ? "10" : fc.GetValues("length").FirstOrDefault();
            //Find Order Column

            string sortColumn = fc.GetValues("order[0][column]") == null ? string.Empty : fc.GetValues("columns[" + fc.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            string sortColumnDir = fc.GetValues("order[0][dir]") == null ? (sortColumn=="" ? "desc" : "asc") : (sortColumn == "" ? "desc" : fc.GetValues("order[0][dir]").FirstOrDefault()) ;
           
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var sort = new ReturnObject().GetSortModels((sortColumn == string.Empty ? defSort : sortColumn), sortColumnDir);

            return new DataTableModelParms { draw = draw , pageSize = pageSize , skip = skip , sort =sort };
        }
            
    }
}
