using ERP.Helpers.Core;
using System;

namespace ERP._System.PostRecords.Dto
{
    public class TransOutput
    {
        public string TransType { get; set; }

        private DateTime _transDate;

        public DateTime TransDate
        {
            get
            {
                return _transDate;
            }
            set
            {
                _transDate = value;
                TransDateStr = _transDate.ToString(Formatters.DateFormat);
            }
        }

        public string TransDateStr { get; set; }

        public string LocationName { get; set; }
    }

}
