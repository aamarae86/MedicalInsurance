namespace ERP.Core.Helpers.Parameters
{
    public class GetAllPagedAndSortedWithParams<T> : BaseParam
    where T : class
    {
        public T Params { get; set; }
    }
}
