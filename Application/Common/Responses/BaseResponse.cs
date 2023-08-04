using System.Net;

namespace Application.Common.Responses;

public class BaseResponse
{
    public BaseResponse(object? data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode.GetHashCode();
        Status = statusCode.ToString();
        Data = data;
    }
    
    public int StatusCode { get; set; }
    public string Status { get; set; }
    public object? Data { get; set; }
}
