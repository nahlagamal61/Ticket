namespace WebAPI.Wrapper
{
    public class CustomPagingResponse<T> : CustomResponse<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public int TotalReasource { get; set; }
        public CustomPagingResponse(T data, string message, int statusCode)
            :base(data, message, statusCode)
        {
            PageIndex = 0;
            PageSize = 5;
            TotalPage = 0;
            TotalReasource = 0;
        }
        public CustomPagingResponse(T data, int pageIndex, int pageSize, string message, int statusCode)
            :base(data,message,statusCode)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Errors = null;
        }
    }
}
