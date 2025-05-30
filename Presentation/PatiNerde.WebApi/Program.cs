﻿using PatiNerde.Persistence;
using PatiNerde.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React projenin çalıştığı port
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // İsteğe bağlı: çerez veya kimlik doğrulama gerekiyorsa
    });
});
builder.Services.AddPersistenceServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatiNerde.WebApi v1");
    });
}
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
