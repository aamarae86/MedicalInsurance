using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models
{
    public static class RowStatusDetail
    {
        public static string NewStatus => DetailRowStatus.RowStatus.New.ToString();
        public static string UpdatedStatus => DetailRowStatus.RowStatus.Updated.ToString();
        public static string DeletedStatus => DetailRowStatus.RowStatus.Deleted.ToString();
        public static string NoActionStatus => DetailRowStatus.RowStatus.NoAction.ToString();
    }
}