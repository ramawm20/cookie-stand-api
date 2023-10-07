using SalmonCookies.DTOs;
using SalmonCookies.Models;

namespace SalmonCookies.Interfaces
{
	public interface ICookieStands
	{
		Task<List<CookieStands>> GetAll();

		Task<CookieStands> GetById(int id);

		Task Delete(int id);

		Task Post (CookieStandsDTO cookieDto);

		Task<CookieStands> Put(int id ,CookieStandsDTO cookieDto);

		Task<List<HourlySales>> CalculatehourlySales(int minimum_customers_per_hour, int maximum_customers_per_hour, double average_cookies_per_sale);



	}
}
