using AspNetCoreMiddleWare.MiddleWare;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    var cultureQuery = context.Request.Query["culture"];
//    if (!string.IsNullOrWhiteSpace(cultureQuery))
//    {
//        var culture=new CultureInfo(cultureQuery);
//        CultureInfo.CurrentCulture = culture;
//        CultureInfo.CurrentUICulture= culture;
//    }
//    await next();
//});
app.UseRequestCulture();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//middleware=> request ve response arasına life cycle girmek istendiğinde bunu en iyi yöntem middle ware ile yapabiliriz