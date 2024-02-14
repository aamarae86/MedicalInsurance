using System;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ResultModels
{
    public class ListResultBaseWithTotalRecords<T> : ListResultBase<T>
        where T : class
    {
        public int totalCount { get; set; }
    }
}