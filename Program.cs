using Microsoft.OpenApi.Models;
using TransactionAPI.Transaction;
using log4net.Config;

// Configure Log4Net
[assembly: XmlConfigurator(ConfigFile = "log4net.config")]

// Setup REST API app
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigureServices();

WebApplication app = builder.Build();

ConfigureSwagger();
ConfigureRouters();

app.Run();

// Config functions
void ConfigureServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Transaction API",
                Description = "An ASP.NET Core Web API for Fourtitude Asia Transactions",
            });
        });
}

void ConfigureSwagger()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}

void ConfigureRouters()
{
    TransactionRouter.Map(app);
}
