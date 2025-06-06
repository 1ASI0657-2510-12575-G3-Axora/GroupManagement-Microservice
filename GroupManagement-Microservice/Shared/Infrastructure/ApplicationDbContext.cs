using DittoBox.API.GroupManagement.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.Shared.Infrastructure
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Group> Groups { get; set; }
		public DbSet<Location> locations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Group>().Property(g => g.FacilityType).HasConversion<string>();

			modelBuilder.Entity<Group>()
				.HasOne(g => g.Location)
				.WithMany()
				.HasForeignKey(g => g.LocationId);
			

		}

	}

}