using System.Net;

namespace billing_system_core.Application.Common.Error;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}