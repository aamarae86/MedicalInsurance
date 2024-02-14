using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
    public class IvInventorySettingSearchDto
    {
        public string SettingNumber { get; set; }
        public long UserId { get; set; }
        public override string ToString() => $"Params.SettingNumber={SettingNumber}&Params.UserId={UserId}";

    }
}
