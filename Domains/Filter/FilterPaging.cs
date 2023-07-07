namespace WebAPI.Filter
{
    public class FilterPaging
    {
        public FilterPaging() {
            PageIndex = 1;
            PageSize = 5;
        }
        public FilterPaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
