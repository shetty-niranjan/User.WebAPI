using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace Common.Logging
{
    public interface ICorrelationIdAccessor
    {
        public string GetCorrelationId(HttpRequestMessage context);
    }
    public class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        public string GetCorrelationId(HttpRequestMessage context)
        {
           return Guid.NewGuid().ToString();
        }
    }
}
