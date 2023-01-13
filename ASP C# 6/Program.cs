using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiplusEF.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ServiplusContext>(builder.Configuration.GetConnectionString("ServiplusEF"));


var app = builder.Build();

app.MapGet("/", () => "Bienvenido a ServiPlus");

app.MapGet("/dbconexion", async ([FromServices] ServiplusContext dbcontext)=>{
    string mensaje = "";
    if (!dbcontext.Database.CanConnect()){
        dbcontext.Database.EnsureCreated();
        mensaje = "Base de datos creada";
    }else{
        mensaje = "Base de datos ya existe";
    }

    return Results.Ok(mensaje);
});

app.MapGet("/Clientes", async ([FromServices] ServiplusContext context)=>{
    context.Cliente.FirstOrDefault();

    return Results.Ok();
});

app.Run();
