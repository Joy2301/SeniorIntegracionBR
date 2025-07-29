using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;
using ExchangeRateOrchestrator.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ExchangeRateCommandHandler>();

builder.Services.AddHttpClient<ExchangeRateApi1Provider>();
builder.Services.AddHttpClient<ExchangeRateApi2Provider>();
builder.Services.AddHttpClient<ExchangeRateApi3Provider>();

builder.Services.AddScoped<IExchangeRateProvider, ExchangeRateApi1Provider>();
builder.Services.AddScoped<IExchangeRateProvider, ExchangeRateApi2Provider>();
builder.Services.AddScoped<IExchangeRateProvider, ExchangeRateApi3Provider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
