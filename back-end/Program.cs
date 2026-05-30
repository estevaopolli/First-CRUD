using System.Net.Mail;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using Microsoft.AspNetCore.Identity;

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

List<User> users = new();

app.MapGet("/usuarios", () =>
{
    return Results.Ok(users);
});

app.MapPost("/signup", (User u) =>
{
    var passwordHasher = new PasswordHasher<User>();
    string hash = passwordHasher.HashPassword(u, u.Password);
    u.Password = hash;

    if (string.IsNullOrEmpty(u.Username))
    {
        return Results.BadRequest(new {message = "Usuário inválido", code = "INVALID_USERNAME"});
    }
    if (string.IsNullOrEmpty(u.Email))
    {
        return Results.BadRequest(new {message = "E-mail inválido", code = "INVALID_EMAIL"});
    }
    if (string.IsNullOrEmpty(u.Password))
    {
        return Results.BadRequest(new {message = "Senha inválida", code = "INVALID_PASSWORD"});
    }

    if(users.Any(uv => uv.Username == u.Username))
    {
        return Results.BadRequest(new{message = "Esse usuário já existe", code="USER_ALREADY_EXISTS"});
    }
    else if (users.Any(uv => uv.Email == u.Email))
    {
        return Results.BadRequest(new {message = "E-mail já cadastrado", code = "EMAIL_ALREADY_EXISTS"});
    }
    else
    {
        users.Add(u);
        return Results.Ok(new {message="Usuário cadastrado com sucesso", code="SUCCESSFUL_REGISTRATION"});
    }
});

app.MapPost("/login", (User u) =>
{
    var passwordHasher = new PasswordHasher<User>();
    var findingUser = users.FirstOrDefault(uv => uv.Email == u.Email);
    if(findingUser != null)
    {
        var hashedPassword = findingUser.Password;
        var passwordVerify = passwordHasher.VerifyHashedPassword(u, hashedPassword, u.Password);

        if (passwordVerify == PasswordVerificationResult.Success)
        {
            return Results.Ok(new {message = "Usuário validado com sucesso", code = "SUCCESSFUL_VALIDATION"});
        }
    }
    return Results.BadRequest(new {message = "E-mail ou Senha incorretos", code = "INCORRECT_CREDENTIALS"});
});

app.Run();
public class User
{
    public string Username {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}

