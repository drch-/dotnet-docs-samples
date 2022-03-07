using Grpc.Net.Client;
using Run.Samples.GrpcPing;

using var channel = GrpcChannel.ForAddress("http://localhost:5000");

var message = "Hello World";
var pingClient = new PingService.PingServiceClient(channel);
var response = await pingClient.SendAsync(new Request { Message = message});

Console.WriteLine("Unary Request/Unary Response");
Console.WriteLine($"  Sent Ping: {message}");
Console.WriteLine($"  Received:\n    Pong: {response.Pong.Message}\n    Server Time: {response.Pong.ReceivedOn.ToDateTime()}");
