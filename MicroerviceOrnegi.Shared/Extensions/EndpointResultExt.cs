using Microsoft.AspNetCore.Http;
using System.Net;

namespace MicroerviceOrnegi.Shared.Extensions
{
    public static class EndpointResultExt
    {
        public static IResult ToGenericResult<T>(this ServiceResult<T> serviceResult)
        {
            return serviceResult.Status switch
            {
                HttpStatusCode.OK => Results.Ok(serviceResult),
                HttpStatusCode.Created => Results.Created(serviceResult.UrlAsCreated, serviceResult),
                HttpStatusCode.NotFound => Results.Problem(serviceResult.Fail!),

                _ => Results.Problem(serviceResult.Fail!)
            };
        }
        public static IResult ToGenericResult(this ServiceResult serviceResult)
        {
            return serviceResult.Status switch
            {
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.NotFound => Results.Problem(serviceResult.Fail!),

                _ => Results.Problem(serviceResult.Fail!)
            };
        }
    }
}
