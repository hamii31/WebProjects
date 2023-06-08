
using Forum.Data.Models;
using ForumApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
	public class ForumDBContext : DbContext
	{
		public ForumDBContext(DbContextOptions<ForumDBContext> options) : base(options)
		{
		}
		public DbSet<Post> Posts { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
