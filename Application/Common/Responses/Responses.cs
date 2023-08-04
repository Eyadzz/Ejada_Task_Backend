using System.Net;

namespace Application.Common.Responses;

public static class Responses
{
    public static BaseResponse NotFound(string entity) => new($"{entity} Not Found", HttpStatusCode.NotFound);

    public static BaseResponse Success() => new();

    public static BaseResponse Success(object data) => new(data);

    public static BaseResponse AlreadyExist(string entity) => new($"{entity} already exists", HttpStatusCode.Conflict);

    public static BaseResponse Unauthorized() => new("Unauthorized", statusCode: HttpStatusCode.Unauthorized);
}