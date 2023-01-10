using Blog_MVC.DAL.Concrete.Configuration;
using Blog_MVC.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DAL.Concrete.Context
{
	public class BlogContext :IdentityDbContext<UserAccount,UserRole,int>
	{
		public DbSet<Article> Article { get; set; }
		public BlogContext(DbContextOptions options) : base(options)
        {

		}
		public BlogContext()
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ArticleConfiguration());

			base.OnModelCreating(builder);	
		}
	}
}
