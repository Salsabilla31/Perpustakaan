namespace PerpustakaanAPP.Api.Base
{
    public class OutputBase
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "Success";
        public bool Success { get; set; } = true;

        public OutputBase() { }

        public OutputBase(int code, Exception ex)
        {
            StatusCode = code;
            Message = ex.Message;
            Success = false;
        }

        public OutputBase(Exception ex)
        {
            StatusCode = 200;
            Message = ex.Message;
            Success = false;
        }

        public void SetError(string message, int statusCode = 500)
        {
            Success = false;
            Message = message;
            StatusCode = statusCode;
        }
    }
}