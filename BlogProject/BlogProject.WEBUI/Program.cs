using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Context;
using BlogProject.Service.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<BlogProjectContext>(options => options.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=HS6BlogProject; Trusted_Connection=true;"));

//.net core övc de tamamen dependency Injection yapoısıyla çalışıyoruz. ICoreService interface inin BaseService ile olan gevşek bağımlılığını tanımlıyoruz. Neerede ICoreService çağırılırsa, onun yerine BaseService gönderilecektir.
builder.Services.AddScoped(typeof(ICoreService<>), typeof(BaseService<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/Account/Login"; //yetki istenilen sayfalara girmek istediğimizde yönlendirileceğimiz sayfa 
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
