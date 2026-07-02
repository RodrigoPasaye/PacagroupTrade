using Pacagroup.Trade.Application.UseCases;
using Pacagroup.Trade.Persistence;
using Pacagroup.Trade.Services.gRPC;
using Pacagroup.Trade.Services.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPresentationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrderService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGrpcReflectionService();

app.Run();
