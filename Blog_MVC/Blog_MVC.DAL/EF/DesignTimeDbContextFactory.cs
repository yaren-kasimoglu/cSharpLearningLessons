using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_MVC.DAL.Concrete.Context;

namespace Blog_MVC.DAL.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<BlogContext>();
            string connectionString = config.GetConnectionString("DB");
            builder.UseSqlServer(connectionString);
            return new BlogContext(builder.Options);
        }
    }
}
