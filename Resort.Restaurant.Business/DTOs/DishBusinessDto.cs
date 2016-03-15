using Resort.Restaurant.Constraints;

namespace Resort.Restaurant.Business.DTOs
{
	public class DishBusinessDto
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DishType Type { get; set; }
	}
}
