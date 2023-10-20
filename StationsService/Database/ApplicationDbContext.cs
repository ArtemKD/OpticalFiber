using Microsoft.EntityFrameworkCore;
using StationsService.Database.Entities;

namespace StationsService.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<StationEF> Stations { get; set; } = null!;
		public DbSet<SettlementEF> Settlements { get; set; }
		public DbSet<RegionEF> Regions { get; set; }
		public DbSet<CountryEF> Countries { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
