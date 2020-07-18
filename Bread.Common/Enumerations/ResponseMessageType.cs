﻿using System.ComponentModel;

namespace Bread.Common.Enumerations
{
    public enum ResponseMessageType
    {
        [Description("Request successful.")]
        Success,
    [Description("Request responded with exceptions.")]
        Exception,
    [Description("Request denied.")]
        UnAuthorized,
    [Description("Request responded with validation error(s).")]
        ValidationError,
    [Description("Unable to process the request.")]
        Failure
    }
}