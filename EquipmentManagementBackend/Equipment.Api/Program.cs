
using Equipment.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Equipment Management API", Version = "v1" });
});

builder.Services.AddSingleton<IEquipmentService, EquipmentService>();
var corsPolicyName = "FrontendCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors(corsPolicyName);

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
