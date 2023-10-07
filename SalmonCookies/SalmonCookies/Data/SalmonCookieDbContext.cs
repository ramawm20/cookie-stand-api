using Microsoft.EntityFrameworkCore;
using SalmonCookies.Models;

namespace SalmonCookies.Data
{
	public class SalmonCookieDbContext  : DbContext
	{
        public SalmonCookieDbContext(DbContextOptions options) : base(options) 
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
		public DbSet<CookieStands> Cookiestands { get; set; }
		public DbSet<HourlySales> HourlySales { get; set; }
	}
}
