namespace SalmonCookies.DTOs
{
	public class CookieStandsDTO
	{
        public string Location { get; set; }

		public string Description { get; set; }

		public int minimum_customers_per_hour { get; set; }

		public int maximum_customers_per_hour { get; set; }

		public double average_cookies_per_sale { get; set; }

		public string Owner { get; set; }

	}
}
