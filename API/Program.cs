using Messaging;
using Microsoft.OpenApi.Models;
using Services.SMS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISmsService, SmsService>();

builder.Services.AddMassTransitWithRabbitMq();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SMS API",
        Version = "v1",
        Description = "API for sending SMS via MassTransit"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMS API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
