﻿using Luck.Framework.Infrastructure;
using Luck.KubeWalnut.Api.AppModules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication<AppWebModule>();
var app = builder.Build();
app.UsePathBase("/kubewalnut");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.InitializeApplication();
app.Run();

