using SQLitePCL;

namespace API.Errors;
public class APIResponse
{
    public APIResponse(int statusCode,string message=null)
    {
        StatusCode = statusCode;
        Message = message
            ?? GetDefaultMessageForStatusCode(StatusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "A bad request, You have made",
            401 => "Authorized, You are not",
            404 => "Resourse found, It was not",
            500 => "Errors sre the path to the dark side",
            _=> null

        };
    }

}
