namespace SalmonCookies.Models
{
	public class HourlySales
	{
		public int Id { get; set; }

        public int CookieStandsId { get; set; }

		public int Value { get; set; }

        public CookieStands Stands { get; set; }
	}
}
