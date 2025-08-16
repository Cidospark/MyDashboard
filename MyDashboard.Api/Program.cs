using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("CorsApp", builder =>
{
    builder.AllowAnyOrigin()
           .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS", "HEAD")
           .AllowAnyHeader();
}));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User Dashboard API",
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

app.UseCors("CorsApp");
app.UseHttpsRedirection();




app.MapGet("/api/users", async ([AsParameters] SearchOptions searchOptions ) =>
{
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        var users = await userRepo.GetUsersAsync();
        
        // filter
        if (!string.IsNullOrEmpty(searchOptions.FirstName) && !string.IsNullOrWhiteSpace(searchOptions.FirstName))
            users = users.Where(x => x.FirstName.ToLower().Contains(searchOptions.FirstName.ToLower()));
        if((int)searchOptions.Gender > 0 && (int)searchOptions.Gender < 4)
            users = users.Where(x => x.Gender == searchOptions.Gender);

        return Results.Ok(new ResponseDto<IEnumerable<AppUser>>()
        {
            Title = "Result of all users.",
            Status = "200",
            Data = users
        });
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("GetUsers");


app.MapGet("/api/users/{id:int}", async (int id) =>
{
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        var user = await userRepo.GetAppUserAsync(id);
        if (user == null)
        {
            return Results.NotFound(new ResponseDto<AppUser>()
            {
                Title = $"No result found for user with id: {id}",
                Status = "404"
            });
        }
        return Results.Ok(new ResponseDto<AppUser>()
            {
                Title = $"Result of user by id: {id}",
                Status = "200",
                Data = user
            });
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("GetUser");


app.MapPost("/api/users", async ([FromBody]AppUser userModel) =>
{
    var responseErrors = new Dictionary<string, List<string>> { };
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        if (userModel == null) {
            responseErrors.Add("Null object", new List<string> { "Provide value to proceed."} );
            return Results.BadRequest(new ResponseDto<AppUser>()
            {
                Title = "One or more validation errors occurred.",
                Status = "400",
                Errors = responseErrors
            });
        }
        
        // Add custom model validation error
        var user = await userRepo.GetAppUserByEmailAsync(userModel.Email);

        if(user != null && user.Email == userModel.Email)
        {
            responseErrors.Add("Email", new List<string> { "Email already exists."} );
            return Results.BadRequest(new ResponseDto<AppUser>()
            {
                Title = "One or more validation errors occurred.",
                Status = "400",
                Errors = responseErrors
            });
        }

        var createdUser = await userRepo.AddAppUserAsync(userModel);

        return Results.Created($"/users/{createdUser.AppUserId}", createdUser);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("AddUser");


app.MapPut("/api/users/{id:int}", async (int id, [FromBody] AppUser model) =>
{
    var responseErrors = new Dictionary<string, List<string>> { };
    // get service
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        var user = await userRepo.GetAppUserAsync(id);
        if (user == null)
        {
            return Results.NotFound(new ResponseDto<AppUser>
            {
                Title = $"No result found for user with id: {id}",
                Status = "404"
            });
        }

        user.DateOfBrith = model.DateOfBrith;
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.Gender = model.Gender;
        user.PhotoPath = model.PhotoPath;

        var updated = await userRepo.UpdateAppUserAsync(user);

        return Results.Ok(new ResponseDto<AppUser>
        {
            Title = $"User:{user.AppUserId} updated successfully.",
            Status = "200",
            Data = user
        });

    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
    
}).WithName("UpdateUser");


app.MapDelete("/api/users/{id:int}", async (int id) =>
{
    var responseErrors = new Dictionary<string, List<string>> { };
    using var scope = app.Services.CreateScope();
    var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    try
    {
        var user = await userRepo.GetAppUserAsync(id);
        if (user == null)
        {
            return Results.NotFound(new ResponseDto<AppUser>
            {
                Title = $"No result found for user with id: {id}",
                Status = "404"
            });
        }

        await userRepo.DeleteAppUserAsync(user.AppUserId);

        return Results.Ok(new ResponseDto<AppUser>
        {
            Title = $"User:{user.AppUserId} deleted successfully",
            Status = "200"
        });
    }
    catch (Exception)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
}
).WithName("DeleteUser");


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