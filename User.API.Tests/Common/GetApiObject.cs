﻿using Microsoft.AspNetCore.Mvc;

namespace User.UnitTest.Common
{
    public static class GetApiObject
    {
        public static T GetObjectResult<T>(this ActionResult<T> result)
        {
            if (result.Result != null)
                return (T)((ObjectResult)result.Result).Value;
            return result.Value;
        }
    }
}
