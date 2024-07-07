using PeakPerformance.DependencyInjection;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Extensions;
using PeakPerformance.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AllApplicationServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

await app.Services.SeedData<ApplicationDbContext>();

app.Run();