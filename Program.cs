
using Diplomka.IdentityServer;
using Diplomka.IdentityServer.Data;
using Diplomka.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddRazorPages();

builder.Services.AddDbContext<IdentityServerDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityServerDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer(option =>
    {
        option.Events.RaiseErrorEvents = true;
        option.Events.RaiseInformationEvents = true;
        option.Events.RaiseFailureEvents = true;
        option.Events.RaiseSuccessEvents = true;

    }).AddAspNetIdentity<ApplicationUser>()
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients);


builder.Services.AddAuthorization();




var app = builder.Build();
SeedData.EnsureSeedData(app);

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages()
    .RequireAuthorization();

app.Run();