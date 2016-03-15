using Resort.Restaurant.Constraints;

namespace Resort.Restaurant.DataAccess.DTOs
{
	public class DishDto
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DishType Type { get; set; }
	}
}
