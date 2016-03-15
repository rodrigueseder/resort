using Resort.Restaurant.Constraints;
using System;

namespace Resort.Restaurant.DataAccess.Models
{
	public class Menu
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime BeginTime { get; set; }
		public DateTime EndTime { get; set; }
		public MenuType Type { get; set; }
	}
}
