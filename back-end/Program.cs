using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontEnd");

List<Registro> users = new();

app.MapGet("/usuarios", () =>
{
    return Results.Ok(users);
});

app.MapPost("/usuarios", (Registro u) =>
{
    if (users.Any(uv => uv.email == u.email))
    {
        return Results.BadRequest(new {message = "E-mail já cadastrado"});
    }
    else if(users.Any(uv => uv.username == u.username))
    {
        return Results.BadRequest(new{message = "Esse nome já existe"});
    }
    else
    {
        users.Add(u);
        return Results.Ok(new {message="Usuário cadastrado com sucesso"});
    }
});

app.Run();
public class Registro
{
    public string username {get; set;}
    public string email {get; set;}
    public string password {get; set;}
}

