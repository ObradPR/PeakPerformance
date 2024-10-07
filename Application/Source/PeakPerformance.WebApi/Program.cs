using PeakPerformance.DependencyInjection;
using PeakPerformance.WebApi.Middlewares;
using PeakPerformance.WebApi.Objects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AllApplicationServices();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IIdentityUser, IdentityUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("https://localhost:4200")
    );

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();