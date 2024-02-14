using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    public class SortModel
    {
        public string ColId { get; set; }
        public string Sort { get; set; } = "desc";
        public string PairAsSqlExpression
        {
            get
            {
                return $"{ColId} {Sort}";
            }
        }

        public override string ToString() => $"OrderByValue.ColId={ColId}&OrderByValue.Sort={Sort}";


    }
}
