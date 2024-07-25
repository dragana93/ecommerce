using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Middleware;
using API.Extensions;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();

//errors controler
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

//images
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
    await AppIdentityDbContextSeed.SeedUserAsync(userManager);
}
catch(Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
