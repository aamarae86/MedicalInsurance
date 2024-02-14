using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto
{
    public class ArJobSurveyPartsListSearchDto
    {
        public string PartsNumber { get; set; }
        public string PartsName { get; set; }
        public long? PartsCategoryLkpId { get; set; }
        public override string ToString()
        {
            return $"Params.PartsNumber={PartsNumber}&Params.PartsName={PartsName}&Params.PartsCategoryLkpId={PartsCategoryLkpId}";
        }
    }
}
