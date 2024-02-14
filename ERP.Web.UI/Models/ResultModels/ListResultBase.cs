using System.Collections.Generic;

namespace ERP.Web.UI.Models.ResultModels
{
    public class ListResultBase<T>
    where T : class
    {
        public List<T> Items { get; set; }

    }
}