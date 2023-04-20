using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using UserApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .AddDataConfiguration()
    .AddHandlers();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "User API (CQRS pattern)",
        Description = "Microservice is for handling users."
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.AddTestData();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();