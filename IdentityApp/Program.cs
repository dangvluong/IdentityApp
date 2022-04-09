using IdentityApp;
using IdentityApp.Models;
using IdentityApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProductDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);


builder.Services.AddDbContext<IdentityDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnectionString"),
    opts => opts.MigrationsAssembly("IdentityApp"));
});

builder.Services.AddScoped<IEmailSender, ConsoleEmailSender>();

builder.Services.AddDefaultIdentity<IdentityUser>(opts =>
{
    opts.Password.RequiredLength = 8;
    opts.Password.RequireDigit = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireNonAlphanumeric = false;
    opts.SignIn.RequireConfirmedAccount = true;

})
.AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddAuthentication().AddGoogle(opts =>
{
    opts.ClientId = builder.Configuration["Google:ClientId"];
    opts.ClientSecret = builder.Configuration["Google:ClientSecret"];
}).AddFacebook(opts =>
{
    opts.AppId = builder.Configuration["Facebook:AppId"];
    opts.AppSecret = builder.Configuration["Facebook:AppSecret"];
});
;
builder.Services.AddHttpsRedirection(opts =>
{
    opts.HttpsPort = 44350;
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});
app.SeedDataToDb();
app.Run();
