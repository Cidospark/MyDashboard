using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Domivue API",
                    Version = "v1",
                });
            });

// Add project specific services
            builder.Services.AddDbContext<MyDashboardDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDashboardDb")));

builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapGet("/users", async () =>
{
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        return Results.Ok(await userRepo.GetUsersAsync());
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("GetUsers");

app.MapGet("/users{id:int}", async (int id) =>
{
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        return Results.Ok(await userRepo.GetAppUserAsync(id));
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("GetUser");

app.MapPost("/users", async ([FromBody]AppUser userModel) =>
{
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        if (userModel == null)
            return Results.BadRequest();

        var createdUser = await userRepo.AddAppUserAsync(userModel);

        return Results.Created($"/users/{createdUser.AppUserId}", createdUser);
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("AddUser");





app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

/*
// {
//   "AllowedHosts": "*",
//   "MyDashboardApiSettings": {
//     "BaseUrl": "https://localhost:5001/api"
//   }
// }
*/