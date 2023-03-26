using HS7_BP.Application.Services.AppUserServices;
using HS7_BP.Application.Services.CategoryRepository;
using HS7_BP.Application.Services.CategoryService;
using HS7_BP.Domain.Entities;
using HS7_BP.Domain.Repositories;
using HS7_BP.Infrastructure.DataAccess;
using HS7_BP.Infrastructure.RepositoriesConcrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//MVC Arch. Pattern kullanacağız dedik.
builder.Services.AddControllersWithViews();

//EntityFramework için oluşturduğumuz nesneyi "BlogumDbContext" ayaga kaldırırken constructor içerisinde istenilen DbContextOptions nesnesini oluşturuyoruz.
builder.Services.AddDbContext<BlogumDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));


//AutoMapper kullanmak istediğimiz ve bunun nasıl resolve edileceğini belirlediğimiz kod parçası
//builder.Services.AddAutoMapper(x => x.AddProfiles(new List<Profile>()
//    {
//        new Mapping(),
//        new MappingUI()

//}));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Kullanıcı Denetimini nasıl yapacağımızı tanıttık. Identity microsoftun hazır kodlar ile bize sunduğu bir kullanıcı denetimi kütüphanesi.
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<BlogumDbContext>().AddDefaultTokenProviders();

//login sayfası belirleme ve hareketsiz kalınca oturum süresini yönetme.
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(30);

    options.LoginPath = "/Account/Login";
    //options.AccessDeniedPath = "//Account/AccessDenied";
    options.SlidingExpiration = true;
});

//.Net Core çekirdeği IoC prensibi ile çalışır. Bu yüzden AspNet Core Mvc için hazırlanan IoC containerlarına hangi talepte hangi nesnenin resolve edileceğini veriyoruz.
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
