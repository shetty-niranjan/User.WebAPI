using Serilog;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class LoggingDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger _logger;
        private readonly ICorrelationIdAccessor _correlationIdAccessor;

        public LoggingDelegatingHandler(ILogger logger, ICorrelationIdAccessor correlationIdAccessor)
        {
            _logger = logger;
            _correlationIdAccessor = correlationIdAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Information("Sending request to {Url}", request.RequestUri);
                request.Headers.Add("CorrelationId", _correlationIdAccessor.GetCorrelationId(request).ToString());
                var response = await base.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    _logger.Information("Received a success response from {Url}", response.RequestMessage.RequestUri);
                }
                else
                {
                    _logger.Information("Received a non-success status code {StatusCode} from {Url}",
                        (int)response.StatusCode, response.RequestMessage.RequestUri);
                }

                return response;
            }
            catch (HttpRequestException ex) 
                when (ex.InnerException is SocketException se && se.SocketErrorCode == SocketError.ConnectionRefused)
            {
                var hostWithPort = request.RequestUri.IsDefaultPort
                    ? request.RequestUri.DnsSafeHost
                    : $"{request.RequestUri.DnsSafeHost}:{request.RequestUri.Port}";

                _logger.Fatal(ex, "Unable to connect to {Host}. Please check the " +
                                        "configuration to ensure the correct URL for the service " +
                                        "has been configured.", hostWithPort);
            }

            return new HttpResponseMessage(HttpStatusCode.BadGateway)
            {
                RequestMessage = request
            };
        }
    }
}
