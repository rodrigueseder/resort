namespace Resort.Restaurant.DataAccess.Models
{
	public class MenuDish
	{
		public Menu Menu { get; set; }
		public Dish Dish { get; set; }
		public bool Default { get; set; }
		public decimal QuantityMax { get; set; }
	}
}
