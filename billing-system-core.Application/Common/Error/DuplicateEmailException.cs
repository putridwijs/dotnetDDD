﻿using System.Net;

namespace billing_system_core.Application.Common.Error;

public class DuplicateEmailException: Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exist.";
}