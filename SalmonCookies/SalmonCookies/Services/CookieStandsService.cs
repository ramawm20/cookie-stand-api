using Microsoft.EntityFrameworkCore;
using SalmonCookies.Data;
using SalmonCookies.DTOs;
using SalmonCookies.Interfaces;
using SalmonCookies.Models;

namespace SalmonCookies.Services
{
	public class CookieStandsService : ICookieStands
	{
		private readonly SalmonCookieDbContext _context;

        public CookieStandsService( SalmonCookieDbContext context)
        {
			_context = context;
        }
        public async Task<List<HourlySales>> CalculatehourlySales(int minimum_customers_per_hour, int maximum_customers_per_hour,double average_cookies_per_sale)
		{
			List<HourlySales> hourlySalesList = new List<HourlySales>();
			Random random = new Random();

			for (int hour = 0; hour < 14; hour++) // Assuming 14 hours of operation
			{
				int customers = random.Next(minimum_customers_per_hour, maximum_customers_per_hour + 1);
				int cookiesSold = (int)(customers * average_cookies_per_sale);

				var hourlySale = new HourlySales
				{
					Value = cookiesSold
				};

				 hourlySalesList.Add(hourlySale);
			}

			return hourlySalesList;
		}

		public async Task Delete(int id)
		{
			var CSDeleted = await _context.Cookiestands.Where(cs => cs.id == id).FirstOrDefaultAsync();

			 _context.Cookiestands.Remove(CSDeleted);

			await _context.SaveChangesAsync();


		}

		public async Task<List<CookieStands>> GetAll()
		{
			var cookieStands = await _context.Cookiestands.ToListAsync();
			return cookieStands;




		}

		public async Task<CookieStands> GetById(int id)
		{
			var CS = await _context.Cookiestands.Where(cs => cs.id == id).FirstOrDefaultAsync();
			return CS;
		}

		public async Task Post(CookieStandsDTO cookieDto)
		{
			int mincph = cookieDto.minimum_customers_per_hour;
			int maxcph = cookieDto.maximum_customers_per_hour;
			double avgcps = cookieDto.average_cookies_per_sale;



			List<HourlySales> hourlySalesList = await CalculatehourlySales(mincph,maxcph,avgcps);
			var CS = new CookieStands()
			{
				Location = cookieDto.Location,
				Description = cookieDto.Description,
				minimum_customers_per_hour = cookieDto.minimum_customers_per_hour,
				maximum_customers_per_hour = cookieDto.maximum_customers_per_hour,
				average_cookies_per_sale = cookieDto.average_cookies_per_sale,
				Owner = cookieDto.Owner,
				HourlySales = hourlySalesList

			};

			await _context.Cookiestands.AddAsync(CS);
			await _context.SaveChangesAsync();
		}

		public async Task <CookieStands> Put(int id, CookieStandsDTO cookieDto)
		{
			var CookieStand = await _context.Cookiestands.FirstOrDefaultAsync(c => c.id == id);

			CookieStand.Location = cookieDto.Location;
			CookieStand.Description = cookieDto.Description;
			CookieStand.minimum_customers_per_hour = cookieDto.minimum_customers_per_hour;
			CookieStand.maximum_customers_per_hour = cookieDto.maximum_customers_per_hour;
			CookieStand.average_cookies_per_sale = cookieDto.average_cookies_per_sale;
			CookieStand.Owner = cookieDto.Owner;

			List<HourlySales> hourlySalesList = await CalculatehourlySales(
				cookieDto.minimum_customers_per_hour,
				cookieDto.maximum_customers_per_hour,
				cookieDto.average_cookies_per_sale
			);

			CookieStand.HourlySales = hourlySalesList;

			await _context.SaveChangesAsync();
			return CookieStand;
		}
	}
}
