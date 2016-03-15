using Resort.Restaurant.Constraints;
using System.Collections.Generic;

namespace Resort.Restaurant.Business.DTOs
{
	public class MenuBusinessDto
	{
		public int Id { get; set; }
		public MenuType Type { get; set; }
		public List<DishBusinessDto> Dishes { get; set; }
	}
}
