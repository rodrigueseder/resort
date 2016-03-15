using Resort.Restaurant.Constraints;
using System.Collections.Generic;

namespace Resort.Restaurant.DataAccess.DTOs
{
	public class MenuDto
	{
		public int Id { get; set; }
		public MenuType Type { get; set; }
		public List<DishDto> Dishes { get; set; }
	}
}
