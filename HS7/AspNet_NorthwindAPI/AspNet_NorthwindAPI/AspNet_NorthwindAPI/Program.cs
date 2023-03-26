using AspNet_NorthwindAPI.Models.dbContext;
using AspNet_NorthwindAPI.Repositories.Abstract;
using AspNet_NorthwindAPI.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer(configuration.GetConnectionString("dbConnection")));

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy =>
    {
        // aşağıdaki kod herhangi bir domainden herhangi bir istek başlığı ile ve herhangi bir metod(action) erişim yetkisi verir. "ne olursan ol gel"
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        
        //sadece withorigins metodunda yazan domainlere izin verir. bu iznin kapsamı tüm metotlardır.
       // policy.WithOrigins("http://localhost:5011", "http://localhost:49418").AllowAnyHeader().AllowAnyMethod();

    });

});


builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() {

        Version = "v1",
        Title = "HS7 Web API",
        Description = "Haftasonu uygulamamız için gerçekleştirdiğimiz swagger",
        Contact = new OpenApiContact
        {
            Name = "Rıdvan Aksoy",
            Url = new Uri("https://www.bilgeadam.com")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
        }

    });

});


builder.Services.AddTransient<NorthwindContext, NorthwindContext>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IShipperRepository, ShipperRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(options => {
    //route yönlendirmesini bu şekilde yapmak zorunda olsakda uygulamayı açınca /index.html olarak çalıştırıyoruz.
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;


});
app.MapControllers();

app.Run();


