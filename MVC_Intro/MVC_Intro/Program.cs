using Microsoft.AspNetCore.Builder;

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

//name: routing name
//pattern: url nasıl bir pattern uygulamasını istiyorsak onu yazıyorız
//default: hangi controller hangi action yönlendirme yapmak istiyorsak onu yazıyoruz

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "customerList", pattern: "customerList", defaults : new {controller="Customer", action= "CustomerList" });  
    endpoints.MapControllerRoute(name: "home", pattern: "home", defaults : new {controller="Home", action= "Index" });

    //default url her zaman en aşağıda bırakıyoruz çünkü yukarıdaki eşleşmeelerden bi sonuç çıkmaz ise default olarak url yönlendirmesi yapacaktır.
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});
//routing
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
