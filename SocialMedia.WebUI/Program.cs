using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Business.Abstrats;
using SocialMedia.Business.Concretes;
using SocialMedia.DataAccess.Abstracts;
using SocialMedia.DataAccess.Concretes;
using SocialMedia.Entities.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();

var con = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SocialMediaDBContext>(opt =>
{
    opt.UseSqlServer(con);
});
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<SocialMediaDBContext>().AddDefaultTokenProviders();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();