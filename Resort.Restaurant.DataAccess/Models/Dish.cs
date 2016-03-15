using Resort.Restaurant.Constraints;

namespace Resort.Restaurant.DataAccess.Models
{
	public class Dish
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DishType Type { get; set; }
	}
}
