namespace WebAPI.Wrapper
{
    public class CustomResponse<T>
    {
        public CustomResponse(T data , string message ,int statusCode)
        {
            Data = data;
            Message = message;
            Errors = null;
            StatusCode = statusCode;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}
