using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
namespace Run.Samples.GrpcPing.Server.Services;

public class PingService : GrpcPing.PingService.PingServiceBase
{
    private readonly ILogger<PingService> _logger;
    public PingService(ILogger<PingService> logger, IConfiguration config)
    {
        _logger = logger;
    }

    public override Task<Response> Send(Request request, ServerCallContext context)
    {
        _logger.LogInformation("Sending ping response");

        return Task.FromResult<Response>(new Response
        {
            Pong = new Pong
            {
                Index = 1,
                Message = request.Message,
                ReceivedOn = Timestamp.FromDateTime(DateTime.UtcNow)
            }
        });
    }

    public override Task<Response> SendUpstream(Request request, ServerCallContext context)
    {
        var newReq = new Request
        {
            Message = request.Message + " (relayed)"
        };
        throw new NotImplementedException();

    }
}