using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Dado/d{numerodefaces}", (
    [FromRoute] int numerodefaces
) => {
    if (numerodefaces <= 0)
    {
        return Results.BadRequest(new {mensagem = "somente dados com apenas uma face"});
    }
    int face =  RandomNumberGenerator.GetInt32(1, numerodefaces + 1);

    return Results.Ok ( new {Dado = $"d{numerodefaces}", rolagem = face});
});

app.Run();
