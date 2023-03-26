using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using StockControlProject.Repositories.Abstract;
using StockControlProject.Repositories.Concrete;
using StockControlProject.Repositories.Context;
using StockControlProject.Service.Abstract;
using StockControlProject.Service.Concrete;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StockControlContext>(option =>
{
    option.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=HS6StockControlDB; Trusted_Connection=true;");
});

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
