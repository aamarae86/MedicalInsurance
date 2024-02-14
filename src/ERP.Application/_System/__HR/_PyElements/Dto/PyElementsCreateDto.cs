using Abp.AutoMapper;
using ERP._System.__Warehouses._PyElements;
using ERP.Helpers.Parameters;

namespace ERP._System.__HR._PyElements.Dto
{
    [AutoMap(typeof(PyElements))]
    public class PyElementsCreateDto : CodeComUtility
    {
        public int ElementSerial { get; set; }
        public string ElementName { get; set; }
        public long ElementTypeLkpId { get; set; }
        public string Description { get; set; }
        public long? DebitAccountId { get; set; }
    }
}
