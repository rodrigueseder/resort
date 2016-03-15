namespace Resort.Restaurant.DataAccess.Models
{
	public class DishItem
	{
		public Dish Dish { get; set; }
		public Item Item { get; set; }
		public decimal Quantity { get; set; }
	}
}
